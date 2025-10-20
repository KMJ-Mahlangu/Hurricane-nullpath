using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);       
        Time.timeScale = 0f;             
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);     
        Time.timeScale = 1f;             
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();         
       
    }

}
