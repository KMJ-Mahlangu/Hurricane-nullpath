using UnityEngine;

public class PickupPromptHandler : MonoBehaviour
{
    [Header("References")]
    public PickUpObject pickupObject;   
    public GameObject pickupPrompt;     
    public float pickupRange = 3f;      

    private Transform player;
    private Camera mainCam;

    private void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        mainCam = Camera.main;

        if (pickupPrompt != null)
            pickupPrompt.SetActive(false);
    }

    private void Update()
    {
        if (pickupObject == null || player == null || pickupPrompt == null) return;

        
        float distance = Vector3.Distance(player.position, pickupObject.transform.position);

        
        bool isPickedUp = pickupObject.IsHeld;

        if (!isPickedUp && distance <= pickupRange)
        {
            
            pickupPrompt.SetActive(true);

            
            pickupPrompt.transform.LookAt(pickupPrompt.transform.position + mainCam.transform.forward);
        }
        else
        {
            
            pickupPrompt.SetActive(false);
        }
    }
}
