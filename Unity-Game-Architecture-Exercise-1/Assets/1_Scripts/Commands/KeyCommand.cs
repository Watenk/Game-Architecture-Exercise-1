using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommand
{
    public KeyCode key;
    public ICommand command;

    public KeyCommand(KeyCode key, ICommand command)
    {
        this.key = key;
        this.command = command;
    }

    public void Check()
    {
        if (Input.GetKeyDown(key))
        {
            command.Execute();
        }
    }
}
