using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyStat _stat;
    [SerializeField] private BodyAttack _bodyAttack;

    [SerializeField] private AttackPatternSO attackPattern;
    [SerializeField] private float attackCooldownTimer = 0f;

    public Transform Target => GameManager.Instance.Player.transform;

    private void Start()
    {
        _bodyAttack.GetComponentInChildren<BodyAttack>();
        _bodyAttack.SetDamage(_stat.Damage);
    }

    private void Update()
    {
        if (attackPattern == null) return;

        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
            return;
        }

        attackPattern.Execute(this);
        attackCooldownTimer = attackPattern.CoolTime;
    }
}
