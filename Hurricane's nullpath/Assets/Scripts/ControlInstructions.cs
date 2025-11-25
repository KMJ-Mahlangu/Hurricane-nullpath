using UnityEngine;

public class ControlInstructions : MonoBehaviour
{
    public Canvas Instructions;
    public GameObject PlatformGround;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instructions.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instructions.gameObject.SetActive(false);
            Destroy(PlatformGround.gameObject);
        }
    }
}
