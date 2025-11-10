using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class SelectFirst : MonoBehaviour
{
    public GameObject FirstSelectedButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectFirstButton()
    {
        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
    }
}
