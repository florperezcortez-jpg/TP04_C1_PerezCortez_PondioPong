using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;

    public void SetPool(ObjectPool pool)
    {
        this.pool = pool;
    }

    public void ReturnToPool()
    {
        if (pool != null)
            pool.ReturnToPool(gameObject);
        else
            Destroy(gameObject);
    }
}