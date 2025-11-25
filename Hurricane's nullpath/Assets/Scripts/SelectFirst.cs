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

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
    }

    // Update is called once per frame
    void Update()
    {

        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
    }

    public void SelectFirstButton()
    {
        if (FirstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
    }
}
