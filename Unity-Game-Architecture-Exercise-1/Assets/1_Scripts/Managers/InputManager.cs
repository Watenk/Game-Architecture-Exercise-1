using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    [SerializeField]
    private GameSettings gameSettings;
    private List<KeyCommand> keyCommands = new List<KeyCommand>();

    ////////////////////////////////////////////////////////////////////

    public void Awake()
    {
        if (gameSettings == null)
        {
            Debug.LogError(this.name + " Is Missing GameSettings Reference");
        }
    }

    public void Start()
    {
        AddKeyCommand(KeyCode.Mouse0, new ShootCameraRayCommand(gameSettings.RayDamage), true);
        AddKeyCommand(KeyCode.W, new WalkUpCommand(FindObjectOfType<Player>()), false);
        AddKeyCommand(KeyCode.A, new WalkLeftCommand(FindObjectOfType<Player>()), false);
        AddKeyCommand(KeyCode.S, new WalkDownCommand(FindObjectOfType<Player>()), false);
        AddKeyCommand(KeyCode.D, new WalkRightCommand(FindObjectOfType<Player>()), false);
    }

    public void Update()
    {
        HandleInput();
    }

    ////////////////////////////////////////////////////////////////////

    public void HandleInput()
    {
        foreach (var currentCommand in keyCommands)
        {
            currentCommand.CheckKeys();
        }
    }

    public void AddKeyCommand(KeyCode key, ICommand command, bool down)
    {
        keyCommands.Add(new KeyCommand(key, command, down));
    }
}