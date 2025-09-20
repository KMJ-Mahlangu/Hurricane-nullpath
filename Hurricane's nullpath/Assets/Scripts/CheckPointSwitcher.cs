using UnityEngine;
using UnityEngine.Rendering;

public class CheckPointSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject entryZone;
    [SerializeField] private GameObject exitZone;

    private void Start()
    {
        exitZone.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            entryZone.SetActive(false);
            exitZone.SetActive(true);
        }
    }
}
