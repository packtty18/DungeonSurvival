using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyBase _base;
    private EnemyStat _stat => _base.Stat;

    [SerializeField] private AttackPatternSO attackPattern;
    [SerializeField] private float attackCooldownTimer = 0f;

    public Transform Target;   //AttackSO 참조
    private void Start()
    {
        _base = GetComponent<EnemyBase>();
    }

    public void Init(EnemyBase enemyBase)
    {
        _base = enemyBase;
        Target = GameManager.Instance.Player.transform;

    }

    private void Update()
    {
        if (_base == null || !_base.IsReady)
        {
            return;
        }
        if (attackPattern == null)
        {
            return;
        }

        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
            return;
        }

        attackPattern.Execute(this);
        attackCooldownTimer = attackPattern.CoolTime;
    }
}
