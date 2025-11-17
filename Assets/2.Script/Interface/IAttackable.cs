using UnityEngine;

public interface IAttackable
{
    float Damage { get; }

    void SetDamage(float damage);
}
