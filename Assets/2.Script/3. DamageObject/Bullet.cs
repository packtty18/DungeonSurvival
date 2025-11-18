using UnityEngine;

public class Bullet : BaseDamageObject
{
    public void Init(Vector3 dir, float damage, float speed, float lifetime)
    {
        SetDamage(damage);
        SetState(new MovingState(dir, speed, lifetime));
    }
}
