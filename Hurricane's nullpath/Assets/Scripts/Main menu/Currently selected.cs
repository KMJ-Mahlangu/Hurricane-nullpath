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
            Hoverclip.Play();
        }

    }

}
