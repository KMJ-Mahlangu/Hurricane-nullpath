using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource ThunderClip;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ThunderClip.Play();
          
        }
    }

    
}
