using UnityEngine;

public class TriggerInstruction : MonoBehaviour
{

    public Canvas instruct;
    public GameObject trigger2;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            instruct.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instruct.gameObject.SetActive(false);
            trigger2.gameObject.SetActive(false);
            Destroy(trigger2.gameObject);
        }
    }
}
