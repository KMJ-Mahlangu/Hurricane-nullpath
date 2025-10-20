using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{

    public GameObject PauseCanvas;
    public GameObject MainMenuCanvas;
    public GameObject Map;
    //public GameObject playerCamera;
    //public GameObject menuCamera;
    public MonoBehaviour PlayerScript;
    public GameObject FirstSelectedButton;
   
    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameResume();
    }

    
    // Update is called once per frame
    void Update()
    {
        bool keyboardPressed = Keyboard.current.pKey.wasPressedThisFrame;
        bool gamepadPressed = Gamepad.current != null && Gamepad.current.xButton.wasPressedThisFrame;

        if (keyboardPressed || gamepadPressed)
        {
            if (isPaused)
                GameResume();
            else
                GamePause();
        }
    }

    public void PressPause()
    {
        isPaused = true;
        PauseCanvas.SetActive(true);
        CursorVisible(true);

        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);

        Map.SetActive(false);
    }
    public void GamePause()
    {
       
    }
   
    public void GameResume()
    {
        isPaused = false;
        PauseCanvas.SetActive(false);

        if (MainMenuCanvas != null)
            MainMenuCanvas.SetActive(true);

        CursorVisible(false);

        if (PlayerScript != null)
            PlayerScript.enabled = true;

        Map.SetActive(true);

    }
    private void CursorVisible(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }


}

