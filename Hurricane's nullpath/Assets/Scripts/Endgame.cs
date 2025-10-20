using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    public GameObject player;
    public GameObject ExitCanvas;
    public GameObject Gate;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExitCanvas.SetActive(true);
            Gate.SetActive(false);
           
        }
    }
    private void OnSceneLoaded(Scene scene,LoadSceneMode node)
    {
        if(scene.buildIndex ==0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void ExitButton()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(0);
    }
}
