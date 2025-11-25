using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeactivateButton : MonoBehaviour
{
    public GameObject player;
   // public GameObject Key;
    public GameObject Button;
    public GameObject Instructiontrigger;

    private void Start()
    {
      Button.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instructiontrigger.SetActive(true);
        if (other.CompareTag("Player"))
        {
            Button.SetActive(true);
           
        }
    }
}
