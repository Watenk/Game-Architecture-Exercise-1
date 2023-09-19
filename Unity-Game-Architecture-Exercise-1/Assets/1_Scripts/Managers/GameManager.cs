using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    private InputManager inputManager;

    public void Awake()
    {
        if (gameSettings == null)
        {
            Debug.LogError(this.name + " Is Missing GameSettings Reference");
        }

        inputManager = new InputManager();
    }

    public void Start()
    {
        inputManager.AddKeyCommand(KeyCode.Mouse0, new CameraRayCommand(gameSettings.RayDamage));
    }

    public void Update()
    {
        inputManager.HandleInput();
    }
}
