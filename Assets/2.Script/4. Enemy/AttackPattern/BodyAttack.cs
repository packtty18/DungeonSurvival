using UnityEngine;

public class BodyAttack : MonoBehaviour, IAttackable
{
    private EnemyStat _stat;
    private float _damage;
    public float Damage => _damage;

    private void Start()
    {
        _stat = GetComponent<EnemyStat>();
        SetDamage(_stat.Damage);
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    
}
