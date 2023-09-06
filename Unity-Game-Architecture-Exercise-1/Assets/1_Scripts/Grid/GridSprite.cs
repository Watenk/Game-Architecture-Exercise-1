using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSprite
{
    public GameObject SpriteGameObject { get; private set; }

    private SpriteRenderer spriteRenderer;

    public GridSprite(GameObject spriteGameObject)
    {
        SpriteGameObject = spriteGameObject;
        spriteRenderer = SpriteGameObject.GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}