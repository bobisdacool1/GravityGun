using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private float liveTime;
    
    public delegate void ObjectDestroyEvent(GameObject destroyedGameObject);

    public event ObjectDestroyEvent OnObjectDestroy;

    public void Start()
    {
        StartCoroutine(WaitAndDestroy(liveTime));
    }

    public void ImmediatelyDestroy()
    {
        OnObjectDestroy?.Invoke(gameObject);
        Destroy(gameObject);
    }

    private IEnumerator WaitAndDestroy(float objectLiveTime)
    {
        yield return new WaitForSeconds(objectLiveTime);
        
        OnObjectDestroy?.Invoke(gameObject);
        Destroy(gameObject);

    }
}
