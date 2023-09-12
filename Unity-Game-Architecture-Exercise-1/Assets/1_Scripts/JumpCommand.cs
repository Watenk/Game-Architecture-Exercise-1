using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    public void Execute()
    {
        Debug.Log("Jump");
    }
}
