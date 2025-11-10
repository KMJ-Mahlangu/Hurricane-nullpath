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
        PauseCanvas.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {


        bool keyboardPressed = Input.GetKeyDown(KeyCode.Escape);
        bool gamepadPressed = Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame;

        
        if (keyboardPressed || gamepadPressed)
        {
            if (isPaused)
                GameResume();
            else
                GamePause();
        }
    }

    
    public void GamePause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (PauseCanvas != null)
            PauseCanvas.SetActive(true);

        if (MainMenuCanvas != null)
            MainMenuCanvas.SetActive(false);

        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);

        if (Map != null)
            Map.SetActive(false);

        CursorVisible(true);
    }
   
    public void GameResume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (PauseCanvas != null)
            PauseCanvas.SetActive(false);

        if (MainMenuCanvas != null)
            MainMenuCanvas.SetActive(true);

        if (PlayerScript != null)
            PlayerScript.enabled = true;

        if (Map != null)
            Map.SetActive(true);

        CursorVisible(false);

    }
    private void CursorVisible(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }


}

