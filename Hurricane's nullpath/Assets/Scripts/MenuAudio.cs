using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioSource menuAudio;
    public AudioSource BackgroundAudio;
    public AudioSource StoryClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuAudio.Play();
    }

    public void StopMusic()
    {
        menuAudio.Stop();
        StoryClip.Stop();
    }

    public void PlayBackground()
    {
        BackgroundAudio.Play();
    }

    public void StoryClipPlay()
    {
        StoryClip.Play();
    }


}
