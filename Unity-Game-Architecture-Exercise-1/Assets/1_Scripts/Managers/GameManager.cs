using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    private InputManager inputManager;

    public void Awake()
    {
        inputManager = new InputManager();
    }

    public void Start()
    {
        inputManager.AddKeyCommand(KeyCode.Mouse0, new CameraRayCommand());
    }

    public void Update()
    {
        inputManager.HandleInput();
    }
}
