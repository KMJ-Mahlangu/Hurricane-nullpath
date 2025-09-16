using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(2);
        }
    }
    private void OnSceneLoaded(Scene scene,LoadSceneMode node)
    {
        if(scene.buildIndex ==2)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
