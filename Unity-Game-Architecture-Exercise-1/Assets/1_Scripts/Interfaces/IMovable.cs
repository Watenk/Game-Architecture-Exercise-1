using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    Rigidbody2D rb { get; set; }

    void Move(Vector2 Direction, float strenght);
}
