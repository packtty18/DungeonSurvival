using UnityEngine;

public class MovingState : IDamageObjectState
{
    private Vector3 direction;
    private float speed;
    private float lifetime;
    private float timer;

    private BaseDamageObject obj;

    public MovingState(Vector3 dir, float speed, float lifetime)
    {
        direction = dir.normalized;
        this.speed = speed;
        this.lifetime = lifetime;
    }

    public void Enter(BaseDamageObject obj)
    {
        this.obj = obj;
        timer = 0f;
    }

    public void Tick(float deltaTime)
    {
        obj.transform.position += direction * speed * deltaTime;
        timer += deltaTime;
        if (timer >= lifetime)
        {
            obj.OnDespawn();
        }
    }

    public void Exit() { }
}
