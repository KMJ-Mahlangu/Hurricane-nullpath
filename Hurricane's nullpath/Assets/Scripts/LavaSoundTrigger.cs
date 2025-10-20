using UnityEngine;
using System.Collections;

public class LavaSoundTrigger : MonoBehaviour
{
    public AudioSource lavaSound;
    public AudioSource lavaSound2;
    public float fadeTime = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeIn(lavaSound, fadeTime));
            StartCoroutine(FadeIn(lavaSound2, fadeTime));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOut(lavaSound, fadeTime));
            StartCoroutine(FadeOut(lavaSound2, fadeTime));
        }
    }

    IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.Play();
        float startVol = 0f;
        audioSource.volume = 0f;

        while (audioSource.volume < 1f)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null;
        }
    }

    IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVol = audioSource.volume;

        while (audioSource.volume > 0f)
        {
            audioSource.volume -= startVol * Time.deltaTime / duration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVol;
    }
}


