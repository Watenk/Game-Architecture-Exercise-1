using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    private List<KeyCommand> keyCommands = new List<KeyCommand>();

    public void HandleInput()
    {
        foreach (var currentCommand in keyCommands)
        {
            if (Input.GetKeyDown(currentCommand.Key))
            {
                currentCommand.Command.Execute();
            }
        }
    }

    public void AddKeyCommand(KeyCode key, ICommand command)
    {
        keyCommands.Add(new KeyCommand(key, command));
    }
}
