using UnityEngine;
using UnityEngine.EventSystems;

public class Currentlyselected : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource Hoverclip;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        
        if (Hoverclip != null)
        {
            // Stop first to reset playback position instantly
           
            Hoverclip.Stop();
            Hoverclip.Play();
        }
    }

    
}
