using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCommand : ICommand
{
    private float rayDamage;

    public CameraRayCommand(float rayDamage)
    {
        this.rayDamage = rayDamage;
    }

    public void Execute()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            IDamagable damagable = hit.collider.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(rayDamage);
            }
        }
    }
}
