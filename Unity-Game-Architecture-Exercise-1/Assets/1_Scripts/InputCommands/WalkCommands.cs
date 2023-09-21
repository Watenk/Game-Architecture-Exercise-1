using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WalkCommand : ICommand
{
    protected Player player;

    public WalkCommand(Player _player) 
    {
        player = _player;
    }

    public abstract void Execute();
}

public class WalkUpCommand : WalkCommand
{
    public WalkUpCommand(Player _player) : base(_player) { }

    public override void Execute()
    {
        player.Move(Vector2.up * Time.deltaTime);
    }
}

public class WalkDownCommand : WalkCommand
{
    public WalkDownCommand(Player _player) : base(_player) { }

    public override void Execute()
    {
        player.Move(Vector2.down * Time.deltaTime);
    }
}

public class WalkLeftCommand : WalkCommand
{
    public WalkLeftCommand(Player _player) : base(_player) { }

    public override void Execute()
    {
        player.Move(Vector2.left * Time.deltaTime);
    }
}

public class WalkRightCommand : WalkCommand
{
    public WalkRightCommand(Player _player) : base(_player) { }

    public override void Execute()
    {
        player.Move(Vector2.right * Time.deltaTime);
    }
}
