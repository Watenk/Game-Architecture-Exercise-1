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

    //Is in Awake because some scripts expect to find the player in the Start() Function
    //Can be fixed with a GameManager
    public void Awake()
    {
        AddActor(PlayerPrefab, new Vector2(1, 1));
    }

    //////////////////////////////////////////////////////////////////////

    public void AddActor(GameObject actorPrefab, Vector2 pos)
    {
        //Add new Actor
        GameObject actorInstance = Instantiate(actorPrefab, new Vector3(pos.x, -pos.y, -1), Quaternion.identity);
        actorInstance.transform.SetParent(this.transform);
        actors.Add(actorInstance);

        //Subscribe to OnDied Event
        ActorBase actorBase = actorInstance.GetComponent<ActorBase>();
        actorBase.OnDied += RemoveActor;
    }

    public void RemoveActor(GameObject actorInstance)
    {
        actors.Remove(actorInstance);
        ActorBase actorBase = actorInstance.GetComponent<ActorBase>();
        actorBase.OnDied -= RemoveActor;
        Destroy(actorInstance);
    }
}
