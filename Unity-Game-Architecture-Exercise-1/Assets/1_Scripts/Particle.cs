using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : Poolable
{
    public delegate void Deactivate(Particle particle);
    public event Deactivate OnDeactivateTimer;

    private ParticleSystem particlSystem;
    private float deactivateTimer;
    private float deactivateTimerAmount;

    public void Start()
    {
        particlSystem = GetComponent<ParticleSystem>();
        deactivateTimerAmount = particlSystem.main.duration;
        gameObject.SetActive(false);
    }

    public override void OnActivate()
    {
        deactivateTimer = deactivateTimerAmount;
        gameObject.SetActive(true);
    }

    public override void OnDeActivate()
    {
        gameObject.SetActive(false);
    }

    public void UpdateTimer()
    {
        deactivateTimer -= Time.deltaTime;

        if (deactivateTimer <= 0)
        {
            OnDeactivateTimer(this);
        }
    }

    public void PlayParticle()
    {
        particlSystem.Play();
    }
}
