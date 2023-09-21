using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particlePrefab;
    public int ParticlePoolSize;

    private ObjectPool<Particle> particlePool = new ObjectPool<Particle>();

    //////////////////////////////////////////////////////////////////////////////

    public void Start()
    {
        //Fill InactivePool
        for (int i = 0; i < ParticlePoolSize; i++)
        {
            GameObject particleInstance = Instantiate(particlePrefab, new Vector3(-100, 100, 0), Quaternion.identity);
            particleInstance.transform.SetParent(this.transform);
            Particle particle = particleInstance.GetComponent<Particle>();
            particlePool.AddObject(particle);
        }
    }

    public void Update()
    {
        for (int i = 0; i < particlePool.activePool.Count; i++)
        {
            particlePool.activePool[i].UpdateTimer();
        }
    }

    /////////////////////////////////////////////////////////////////////////////

    public void PlayParticle(Vector2 _pos)
    {
        Particle newParticle = particlePool.RequestObject(_pos);
        newParticle.OnDeactivateTimer += DeActivateParticle;
        newParticle.PlayParticle();
    }

    private void DeActivateParticle(Particle particle)
    {
        particle.OnDeactivateTimer -= DeActivateParticle;
        particlePool.ReturnObject(particle);
    }
}
