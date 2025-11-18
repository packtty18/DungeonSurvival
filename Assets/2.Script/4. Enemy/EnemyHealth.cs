using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    private EnemyBase _base;
    private EnemyStat _stat => _base.Stat;
    private EnemyAnimation _animation => _base.Animation;
    private ItemDropper _item;
    public float MaxHealth => _stat.MaxHealth;
    public float CurrentHealth => _stat.Health;

    private void Start()
    {
        _item = GetComponent<ItemDropper>();

    }

    public void Init(EnemyBase enemyBase)
    {
        _base = enemyBase;
    }

    public void OnDead()
    {
        _animation?.SetDead(true);
        _base.IsReady = false;
        _base.SetColliderEnable(false);
        _item?.SpawnRandomItem();
        // 3초 후에 비활성화
        StartCoroutine(DeactivateAfterSeconds(3f));
    }

    private IEnumerator DeactivateAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        _base.OnDespawn();
    }

    public void OnHeal(float amount)
    {
        if (_base == null || !_base.IsReady)
        {
            return;
        }

        _stat?.SetHealth(Mathf.Max(CurrentHealth + amount, MaxHealth));
    }

    public void OnHit(float amount)
    {
        if (!_base.IsReady)
        {
            return;

        }
        _stat?.SetHealth(Mathf.Max(CurrentHealth - amount, 0));

        if (CurrentHealth <= 0)
        {
            OnDead();
        }
        else
        {
            //_base.Move.ApplyKnockback();
            _animation?.SetOnHit();
        }
    }
}
