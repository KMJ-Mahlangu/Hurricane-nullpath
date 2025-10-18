using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject FirstSelectedButton;

    public MonoBehaviour PlayerScript;

    private void Start()
    {
        
        CursorVisible(true);

        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
    }

    public void Play()
    {
        if (MainMenuCanvas !=null)
            MainMenuCanvas.SetActive(true);
        CursorVisible(false);
       
        if (PlayerScript!=null)
            PlayerScript.enabled = true;
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
}
