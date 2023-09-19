using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private List<KeyCommand> keyCommands = new List<KeyCommand>();

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