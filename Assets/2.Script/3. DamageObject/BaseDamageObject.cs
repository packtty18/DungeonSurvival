using UnityEngine;

public abstract class BaseDamageObject : MonoBehaviour, IPoolable, IAttackable
{
    // 공격력
    public float Damage { get; private set; }

    // 공격 타입에 따라 움직이는지 여부 판단
    protected bool isMoving = false;

    // 이동 상태를 위한 State 패턴
    protected IDamageObjectState _state;

    public virtual void OnSpawn()
    {
        _state?.Enter(this);
        gameObject.SetActive(true);
    }

    public virtual void OnDespawn()
    {
        gameObject.SetActive(false);
        _state?.Exit();
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    protected virtual void Update()
    {
        _state?.Tick(Time.deltaTime);
    }

    public void SetState(IDamageObjectState newState)
    {
        _state?.Exit();
        _state = newState;
        _state?.Enter(this);
    }
}
