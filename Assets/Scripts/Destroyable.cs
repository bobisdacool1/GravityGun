using System.Collections;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private float liveTime;
    
    public delegate void ObjectDestroyEvent(GameObject destroyedGameObject);
    public event ObjectDestroyEvent OnObjectDestroy;

    private void Start()
    {
        StartCoroutine(DestroyInSeconds(liveTime));
    }

    public void ImmediatelyDestroy()
    {
        OnObjectDestroy?.Invoke(gameObject);
        Destroy(gameObject);
    }

    public IEnumerator DestroyInSeconds(float objectLiveTime)
    {
        yield return new WaitForSeconds(objectLiveTime);
        
        ImmediatelyDestroy();
    }
}
