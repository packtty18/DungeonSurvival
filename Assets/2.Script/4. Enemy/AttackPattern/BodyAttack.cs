using UnityEngine;

public class BodyAttack : MonoBehaviour, IAttackable
{
    private float _damage;
    public float Damage => _damage;

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    
}
