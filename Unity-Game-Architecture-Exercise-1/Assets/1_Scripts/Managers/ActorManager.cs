using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject CowPrefab;
    public GameObject FlyPrefab;

    private List<GameObject> actors = new List<GameObject>();

    //////////////////////////////////////////////////////////////////////

    public void Start()
    {
        AddActor(PlayerPrefab, new Vector2(1, 1));
        AddActor(CowPrefab, new Vector2(10, 1));
        AddActor(FlyPrefab, new Vector2(10, 1));
    }

    //////////////////////////////////////////////////////////////////////

    public void AddActor(GameObject actorPrefab, Vector2 pos)
    {
        GameObject actorInstance = Instantiate(actorPrefab, new Vector3(pos.x, -pos.y, -1), Quaternion.identity);
        ActorBase actorBase = actorInstance.GetComponent<ActorBase>();
        actorBase.OnDied += RemoveActor;
        actors.Add(actorInstance);
    }

    public void RemoveActor(GameObject actorInstance)
    {
        actors.Remove(actorInstance);
        ActorBase actorBase = actorInstance.GetComponent<ActorBase>();
        actorBase.OnDied -= RemoveActor;
        Destroy(actorInstance);
    }
}
