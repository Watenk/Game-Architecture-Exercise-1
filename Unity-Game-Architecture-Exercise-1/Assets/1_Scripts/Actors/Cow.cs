using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : ActorBase
{
    private SpriteRenderer spriteRenderer;
    private GameObject player;

    public override void Start()
    {
        base.Start();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = FindObjectOfType<Player>().gameObject;
    }

    public override void Update()
    {
        base.Update();

        if (Vector2.Distance(player.transform.position, transform.position) < 5)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.gray;
        }
    }
}
