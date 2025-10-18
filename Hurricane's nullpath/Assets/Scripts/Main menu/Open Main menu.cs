using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using JetBrains.Annotations;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor.Build;

public class OpenMainmenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject SettingsMenuCanvas;

    [SerializeField] private GameObject MainMenuButtonOne;
    
    private bool GamePause;

    public GameObject player;

    private void Start()
    {
        MainMenuCanvas.SetActive(true);
        SettingsMenuCanvas.SetActive(false);
       player.SetActive(false);

    }

    private void OpenSettingsHandler()
    {
        MainMenuCanvas.SetActive(true);
        SettingsMenuCanvas.SetActive(true);
    }


    private void Update()
    {
        /*if (Inputmanager.inst.MenuOpenInput)
        {
            if (!GamePause)
            {
                PauseGame();
            }

            else
            {
                PlayGame();
            }
        }*/

        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            OnBackPress();
        }

        if (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            OnBackPress();
        }


    }

    public void OnSettingsPressing()
    {
        OpenSettingsHandler();
    }

   /* public void ResumePressing()
    {
        PlayGame();
    }*/
    public void OnSettingBackPressing()
    {
        MenuOpen();
    }
   /* public void PauseGame()
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
    }*/

    public void MenuOpen()
    {
        MainMenuCanvas.SetActive(true);
        SettingsMenuCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(MainMenuButtonOne);
    }

    public void MenuClose()
    {
        MainMenuCanvas.SetActive(false);
        SettingsMenuCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnBackPress()
    {
        MenuOpen();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}