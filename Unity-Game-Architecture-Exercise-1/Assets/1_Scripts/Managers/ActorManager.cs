using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    private List<ActorBase> actors = new List<ActorBase>();

    //////////////////////////////////////////////////////////////////////

    public void Awake()
    {
        if (gameSettings == null)
        {
            Debug.LogError(this.name + " Is Missing GameSettings Reference");
        }
    }

    public void Start()
    {
        //Player
        IState[] playerStates = 
        {
            new EnemyIdleState(),
            new EnemyAttackState(),
        };
        AddActor(new Cow(gameSettings.MaxCowHealth, typeof(EnemyIdleState), playerStates));
    }

    public void Update()
    {
        for (int i = 0; i < actors.Count; i++)
        {
            actors[i].OnUpdate();
        }
    }

    //////////////////////////////////////////////////////////////////////

    private void AddActor(ActorBase newActor)
    {
        actors.Add(newActor);
    }
}
