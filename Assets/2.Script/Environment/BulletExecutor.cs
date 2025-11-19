using UnityEngine;

public class BulletExecutor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            return;
        }

        if(!collision.TryGetComponent(out AttackBox attack))
        {
            return;
            

        }

        if(attack.Owner == null || !attack.Owner.TryGetComponent(out IPoolable pool))
        {
            return;
        }

        pool.OnDespawn();
    }
}
