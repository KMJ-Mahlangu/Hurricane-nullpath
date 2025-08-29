using UnityEngine;


public class Deactivator : MonoBehaviour
{
    public GameObject player;
    public GameObject challenge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        challenge.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            challenge.SetActive(false);
        }
    }
}
