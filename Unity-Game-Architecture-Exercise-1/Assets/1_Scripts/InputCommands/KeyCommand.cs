using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommand
{
    public KeyCode key;
    public ICommand command;
    public bool Down;

    public KeyCommand(KeyCode _key, ICommand _command, bool _down)
    {
        key = _key;
        command = _command;
        Down = _down;
    }

    ////////////////////////////////////////////////////


    //Probably Inefficient
    public void CheckKeys()
    {
        if (Down)
        {
            if (Input.GetKeyDown(key))
            {
                command.Execute();
            }
        }
        else
        {
            if (Input.GetKey(key))
            {
                command.Execute();
            }
        }
    }
}
