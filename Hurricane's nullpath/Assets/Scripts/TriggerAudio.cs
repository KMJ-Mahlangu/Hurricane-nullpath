using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource NPCClip;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            NPCClip.Play();
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            NPCClip.Stop();
        }
    }
}
