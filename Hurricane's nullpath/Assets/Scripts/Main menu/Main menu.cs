using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject OptionsCanvas;
    public GameObject OptionsFirstSelected;
    public GameObject FirstSelectedButton;
    public GameObject Map;
    public GameObject MenuCamera;
    public GameObject PlayerCamera;
   // public GameObject PauseCanvas;


    public MonoBehaviour PlayerScript;
    public MonoBehaviour pauseCanvas;

    private void Start()
    {
        
        CursorVisible(true);

        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
        if (pauseCanvas != null)
            pauseCanvas.enabled = false;
        
        
        
        Map.SetActive(false);
    }
    

    

    public void Play()
    {
        if (MainMenuCanvas !=null)
            MainMenuCanvas.SetActive(true);
        CursorVisible(false);
       
        if (PlayerScript!=null)
            PlayerScript.enabled = true;

        Map.SetActive(true);
        PlayerCamera.SetActive(true);
        MenuCamera.SetActive(false);

        if (pauseCanvas != null)
            pauseCanvas.enabled = true;

    }

    private void CursorVisible(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        CursorVisible(true);

        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
        if (pauseCanvas != null)
            pauseCanvas.enabled = false;



        Map.SetActive(false);
    }

    public void BackButton()
    {
        OptionsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true );

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
    
}
    public void Options()
    {
        MainMenuCanvas.SetActive(false );
        OptionsCanvas.SetActive(true );

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OptionsFirstSelected);
    }
}
