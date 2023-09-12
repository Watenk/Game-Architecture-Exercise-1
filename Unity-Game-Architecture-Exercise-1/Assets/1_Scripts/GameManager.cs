using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InputHandler inputHandler;

    void Start()
    {
        inputHandler = new InputHandler();
        inputHandler.AddKeyCommand(KeyCode.W, new JumpCommand());
    }

    void Update()
    {
        inputHandler.HandleInput();
    }
}
