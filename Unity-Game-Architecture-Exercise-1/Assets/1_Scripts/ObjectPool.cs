using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Poolable
{
    public List<T> activePool = new List<T>();
    public List<T> inactivePool = new List<T>();

    /////////////////////////////////////////////////////

    public void AddObject(T newObject)
    {
        inactivePool.Add(newObject);
    }

    public T RequestObject(Vector2 _pos)
    {
        if (inactivePool.Count > 0)
        {
            T activatedT = ActivateT(inactivePool[0]);
            activatedT.transform.position = new Vector3(_pos.x, _pos.y, -1);
            return activatedT;
        }
        else
        {
            Debug.Log(typeof(T).Name + " InactivePool is empty");
            return null;
        }
    }

    public void ReturnObject(T objectToReturn)
    {
        DeActivateT(objectToReturn);
    }

    private T ActivateT(T objectToActivate)
    {
        inactivePool.Remove(objectToActivate);
        activePool.Add(objectToActivate);
        objectToActivate.OnActivate();
        return objectToActivate;
    }

    private void DeActivateT(T objectToDeActivate)
    {
        activePool.Remove(objectToDeActivate);
        inactivePool.Add(objectToDeActivate);
        objectToDeActivate.OnDeActivate();
    }
}