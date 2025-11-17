using UnityEngine;

public abstract class AttackPatternSO : ScriptableObject, IAttackPattern
{
    public float CoolTime = 1f;

    public abstract void Execute(EnemyAttack owner);
}
