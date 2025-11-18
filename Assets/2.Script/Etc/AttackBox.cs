using UnityEngine;
using System.Collections.Generic;

public class AttackBox : MonoBehaviour
{
    public SpawnType type;
    public bool AutoDestroyOnHit = false;
    [SerializeField] private float damageMultiplier = 1f;
    public float DamageMultiplier => damageMultiplier;

    [SerializeField] private float hitCooldown = 1f; // 같은 대상에게 재피격까지 시간
    private Dictionary<IHealth, float> _hitTimers = new Dictionary<IHealth, float>();

    
    public GameObject Owner { get; private set; }

    private void Awake()
    {
        Owner = transform.parent.gameObject;

        if (Owner == null)
            Debug.LogError($"[AttackBox] Owner(IAttackable) not found({name})");
    }

    private void Update()
    {
        // 타이머 감소
        List<IHealth> keys = new List<IHealth>(_hitTimers.Keys);
        foreach (var key in keys)
        {
            _hitTimers[key] -= Time.deltaTime;
            if (_hitTimers[key] <= 0)
                _hitTimers.Remove(key);
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null)
            return;

        if (!collision.TryGetComponent(out HitBox hitBox))
            return;

        if (hitBox.Type == type)
            return; // 같은 진영이면 데미지 없음

        if (!Owner.TryGetComponent(out IAttackable attack))
            return;

        IHealth target = hitBox.Owner;
        if (target != null)
        {
            // 타이머 체크: 아직 쿨타임 안 지남
            if (_hitTimers.ContainsKey(target))
                return;

            float finalDamage = attack.Damage * hitBox.DamageMultiplier * DamageMultiplier;
            target.OnHit(finalDamage);
            Debug.Log($"[AttackBox] {collision.name} took {finalDamage} damage");

            // 타이머 시작
            _hitTimers[target] = hitCooldown;
        }

        if(AutoDestroyOnHit)
        {
            if(Owner.TryGetComponent(out IPoolable poolable))
            {
                poolable.OnDespawn(); 
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
