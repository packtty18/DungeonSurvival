using UnityEngine;

public class StaticState : IDamageObjectState
{
    //이동하지 않는 공격
    private BaseDamageObject _obj;
    private float duration;
    private float timer;

    public StaticState(float duration)
    {
        this.duration = duration;
    }

    public void Enter(BaseDamageObject obj)
    {
        _obj = obj;
        timer = 0f;
    }

    public void Tick(float deltaTime)
    {
        timer += deltaTime;
        if (timer >= duration)
        {
            _obj.OnDespawn(); // 지속시간 후 소멸
        }
    }

    public void Exit() { }
}
