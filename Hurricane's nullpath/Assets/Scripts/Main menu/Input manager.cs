using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Inputmanager : MonoBehaviour
{
    public static Inputmanager inst;
    public bool MenuOpenInput { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _MenuOpenAction;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        _playerInput = GetComponent<PlayerInput>();
        _MenuOpenAction = _playerInput.actions["MenuOpen"];
    }

    private void Update()
    {
        MenuOpenInput = _MenuOpenAction.WasPressedThisFrame();
    }
}
