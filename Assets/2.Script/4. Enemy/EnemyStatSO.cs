using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/Stat", fileName = "EnemyStat")]
public class EnemyStatSO : ScriptableObject
{
    [Header("Health")]
    public float MaxHealth = 10f;

    [Header("Move")]
    public float MoveSpeed = 1.5f;

    [Header("Damage")]
    public float Damage = 5f;

    public bool IsTargetToPlayer = true;
}
