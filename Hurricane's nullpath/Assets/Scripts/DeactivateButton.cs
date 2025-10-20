using UnityEngine;
using UnityEngine.InputSystem;

public class DeactivateButton : MonoBehaviour
{
    public GameObject player;
   // public GameObject Key;
    public GameObject Button;
  

    private void Start()
    {
      
      Button.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            Button.SetActive(true);

        }
    }
}
