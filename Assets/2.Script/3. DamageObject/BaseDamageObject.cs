using UnityEngine;

public abstract class BaseDamageObject : MonoBehaviour, IPoolable, IAttackable
{
    // 공격력
    public float Damage { get; private set; }

    // 공격 타입에 따라 움직이는지 여부 판단
    protected bool isMoving = false;

    // 이동 상태를 위한 State 패턴
    protected IDamageObjectState state;

    public virtual void OnSpawn()
    {
        state?.Enter(this);
        gameObject.SetActive(true);
    }

    public virtual void OnDespawn()
    {
        gameObject.SetActive(false);
        state?.Exit();
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    protected virtual void Update()
    {
        state?.Tick(Time.deltaTime);
    }

    public void SetState(IDamageObjectState newState)
    {
        state?.Exit();
        state = newState;
        state?.Enter(this);
    }
}
