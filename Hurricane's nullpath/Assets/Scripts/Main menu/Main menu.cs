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
    

    public MonoBehaviour PlayerScript;


    private void Start()
    {
        
        CursorVisible(true);

        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
        Map.SetActive(false);
    }
    

    private void Update()
    {

      


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
        //SceneManager.LoadScene(0);
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
