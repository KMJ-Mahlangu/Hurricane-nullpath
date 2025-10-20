using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 9f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Look Settings")]
    public Transform cameraTransform;
    public float lookSensitivity = 2f;
    public float verticalLookLimit = 90f;

    [Header("Animation Settings")]
    public Animator animator;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;
    private float verticalRotation = 0f;

    private bool isSprinting = false;

    [Header("PickUp Settings")]
    public float pickUpRange = 3f;
    public Transform holdpoint;
    private PickUpObject heldObject;
    public LayerMask pickUpLayer;
    public PlayerKeyInventory playerInventory;


    [Header("Inspect Settings")]
    public Transform inspectPoint;
    public float inspectMoveSpeed = 10f;

    private bool isInspecting = false;

   /* [Header("Throw Settings")]
    public float throwForce = 10f;
    public float throwUpwardBoost = 1f;*/


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Contains("Level 1"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    private void Update()
    {
        HandleMovement();
        if (!isInspecting)
        {
            HandleLook();
        }
        
      
        if (heldObject != null)
        {
            if (isInspecting)
            {
                heldObject.MoveToInspect(inspectPoint.position);
                heldObject.RotateHeld(lookInput);
            }
            else
            {
                heldObject.MoveToHoldPoint(holdpoint.position);
            }

        }

        if(animator != null)
        {
            bool isGrounded  = controller.isGrounded;
            bool isMoving = moveInput.magnitude > 0.1f;

            animator.SetBool("isWalking", isMoving && !isSprinting && isGrounded);
            animator.SetBool("isRunning", isMoving && isSprinting && isGrounded);
            animator.SetBool("isGrounded", isGrounded);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(animator != null)
        {
            bool isMoving = moveInput.magnitude > 0.1f;
            animator.SetBool("isWalking", isMoving && !isSprinting);
            animator.SetBool("isRunning", isMoving && isSprinting);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.performed) isSprinting = true;
        if (context.canceled) isSprinting = false;

        Debug.Log("Sprinting Input Detected: " + context.phase);

        if (animator!=null)
        {
            bool isMoving = moveInput.magnitude > 0.1f;
            animator.SetBool("isRunning", isSprinting && isMoving);
            animator.SetBool("isWalking", !isSprinting && isMoving);
        }
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (heldObject == null)
        {
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange, pickUpLayer))
            {
                PickUpObject pickUp = hit.collider.GetComponent<PickUpObject>();
                if (pickUp != null)
                {

                    pickUp.PickUp(holdpoint, playerInventory); 
                    heldObject = pickUp;
                    Physics.IgnoreCollision(heldObject.GetComponent<Collider>(), controller, true);
                }
            }
        }
        else
        {
            heldObject.Drop();
            Physics.IgnoreCollision(heldObject.GetComponent<Collider>(), controller, false);
            heldObject = null;
        }
    }


    /* public void OnThrow(InputAction.CallbackContext context)
     {
         if (!context.performed) return;
         if (heldObject == null) return;

         Vector3 dir = cameraTransform.forward;
         Vector3 impulse = dir * throwForce + Vector3.up * throwUpwardBoost;

        // heldObject.Throw(impulse);
        // heldObject = null;
     }*/

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }
    }

    public void HandleMovement()
    {
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        Vector3 move = transform.right * moveInput.x + transform.forward *moveInput.y;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void HandleLook()
    {
      
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit,
        verticalLookLimit);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    public void OnInspect(InputAction.CallbackContext context)
    {
        if (heldObject == null) return;
        if(context.performed)
        {
            isInspecting = true;
            lookInput = Vector2.zero;
            Debug.Log("Now Inspecting");
        }
        else if(context.canceled)
        {
            isInspecting = false;
        }
    }




}