using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommand
{
    public KeyCode Key;
    public ICommand Command;

    public KeyCommand(KeyCode key, ICommand command)
    {
        Key = key;
        Command = command;
    }
}
