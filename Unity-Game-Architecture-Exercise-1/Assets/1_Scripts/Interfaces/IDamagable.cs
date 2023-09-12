using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    float Health { get; set; }

    void TakeDamage(float damage, TileData tileData)
    {
        Health -= damage * tileData.DamageMultiplier;
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die();
}
