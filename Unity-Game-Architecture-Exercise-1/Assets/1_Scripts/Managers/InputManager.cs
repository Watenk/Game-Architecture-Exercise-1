using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    public GameObject rayClickParticle;

    [SerializeField]
    private GameSettings gameSettings;
    private List<KeyCommand> keyCommands = new List<KeyCommand>();

    public void Awake()
    {
        if (gameSettings == null)
        {
            Debug.LogError(this.name + " Is Missing GameSettings Reference");
        }

        AddKeyCommand(KeyCode.Mouse0, new CameraRayCommand(gameSettings.RayDamage));
    }

    public void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        foreach (var currentCommand in keyCommands)
        {
            currentCommand.Check();
        }
    }

    public void AddKeyCommand(KeyCode key, ICommand command)
    {
        keyCommands.Add(new KeyCommand(key, command));
    }
}