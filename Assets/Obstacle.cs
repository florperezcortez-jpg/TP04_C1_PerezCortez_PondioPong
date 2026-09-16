using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float minLifetime = 3f;
    [SerializeField] private float maxLifetime = 7f;

    private PooledObject pooledObject;

    void Awake()
    {
        pooledObject = GetComponent<PooledObject>();
    }

    void OnEnable()
    {
        float lifetime = Random.Range(minLifetime, maxLifetime);
        Invoke(nameof(ReturnToPool), lifetime);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    private void ReturnToPool()
    {
        pooledObject.ReturnToPool();
    }
}