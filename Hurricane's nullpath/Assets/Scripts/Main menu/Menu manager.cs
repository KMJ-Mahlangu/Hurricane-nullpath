using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using JetBrains.Annotations;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menumanager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
     [SerializeField] private GameObject SettingsMenuCanvas;

    [SerializeField] private GameObject MainMenuButtonOne;

    private bool GamePause;

    private void Start()
    {
        MainMenuCanvas.SetActive(false);
       SettingsMenuCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Inputmanager.inst.MenuOpenInput)
        {
            if (!GamePause)
            {
                PauseGame();
            }

            else
            {
                PlayGame();
            }
        }

        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            OnBackPress();
        }

        if (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            OnBackPress();
        }


    }
    public void PauseGame()
    {
        GamePause = true;
        Time.timeScale = 0f;

        MenuOpen();
    }

    public void PlayGame()
    {
        GamePause = false;
        Time.timeScale = 1f;

        MenuClose();
    }

    public void MenuOpen()
    {
        MainMenuCanvas.SetActive(true);
        SettingsMenuCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(MainMenuButtonOne);
    }

    public void MenuClose()
    {
        MainMenuCanvas.SetActive(false);
        SettingsMenuCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null); 
    }

    public void OnBackPress()
    {
        MenuOpen();
    }
}