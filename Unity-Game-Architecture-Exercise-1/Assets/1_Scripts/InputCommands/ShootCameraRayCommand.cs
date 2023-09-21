using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCameraRayCommand : ICommand
{
    private float rayDamage;

    public ShootCameraRayCommand(float _rayDamage)
    {
        rayDamage = _rayDamage;
    }

    /////////////////////////////////////////////////////////

    public void Execute()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            IDamagable damagable = hit.collider.GetComponent<IDamagable>();
            damagable?.TakeDamage(rayDamage);
        }
    }
}
