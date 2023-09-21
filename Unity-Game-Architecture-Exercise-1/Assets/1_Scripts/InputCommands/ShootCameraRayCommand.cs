using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCameraRayCommand : ICommand
{
    private float rayDamage;
    private ParticleManager particleManager;

    public ShootCameraRayCommand(float _rayDamage, ParticleManager _particleManager)
    {
        rayDamage = _rayDamage;
        particleManager = _particleManager;
    }

    /////////////////////////////////////////////////////////

    public void Execute()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        particleManager.PlayParticle(new Vector2(mousePos.x, mousePos.y));

        if (hit.collider != null)
        {
            IDamagable damagable = hit.collider.GetComponent<IDamagable>();
            damagable?.TakeDamage(rayDamage);
        }
    }
}
