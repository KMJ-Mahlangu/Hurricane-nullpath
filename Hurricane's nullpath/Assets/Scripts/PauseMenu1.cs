using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject MainMenuCanvas;
    //public GameObject Map;
    public MonoBehaviour PlayerScript;
    public GameObject FirstSelectedButton;
    public GameObject OptionsCanvas;
    public GameObject OptionsFirstSelected;
    public MonoBehaviour pauseCanvas;
    private bool isPaused = false;

    void Start()
    {
       // GameResume();
        if (PauseCanvas != null)
            PauseCanvas.SetActive(false);
    }

    void Update()
    {
        bool keyboardPressed = Input.GetKeyDown(KeyCode.Escape);
        bool gamepadPressed = Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame;

        // Toggle pause on press
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

      //  if (Map != null)
        //    Map.SetActive(false);

        CursorVisible(true);
    }

    public void GameResume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (PauseCanvas != null)
            PauseCanvas.SetActive(false);

        if (MainMenuCanvas != null)
            MainMenuCanvas.SetActive(false);

        if (PlayerScript != null)
            PlayerScript.enabled = true;

       // if (Map != null)
        //    Map.SetActive(true);

        CursorVisible(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

        isPaused = true;
        Time.timeScale = 1f;

        if (PauseCanvas != null)
            PauseCanvas.SetActive(false);

        if (MainMenuCanvas != null)
            MainMenuCanvas.SetActive(true);

        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);

        //  if (Map != null)
        //    Map.SetActive(false);

        CursorVisible(true);
    }
    public void Options()
    {
        MainMenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OptionsFirstSelected);
    }

    public void Quit()
    {
        Application.Quit();
    }


    private void CursorVisible(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
    public void BackButton()
    {
        //OptionsCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstSelectedButton);

    }
}


