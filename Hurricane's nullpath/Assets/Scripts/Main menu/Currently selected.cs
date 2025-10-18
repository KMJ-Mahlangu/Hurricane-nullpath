using UnityEngine;
using UnityEngine.EventSystems;

public class Currentlyselected : MonoBehaviour , IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
