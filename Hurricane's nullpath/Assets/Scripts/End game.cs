using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
   // public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
            



        }

    }
    }
