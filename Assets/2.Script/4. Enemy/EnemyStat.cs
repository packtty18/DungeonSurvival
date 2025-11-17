using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [Header("Runtime Stats")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isTargetToPlayer;

    public float MaxHealth => _maxHealth;
    public float Health => _health;
    public float Damage => _damage;
    public float MoveSpeed => _moveSpeed;
    public bool IsTargetToPlayer => _isTargetToPlayer;


    [Header("Base Stat SO")]
    [SerializeField] private EnemyStatSO _baseStat;

    private void Start()
    {
        if (_baseStat != null)
        {
            ApplyBaseStat(_baseStat);
        }
    }

    private void ApplyBaseStat(EnemyStatSO stat)
    {
        _maxHealth = stat.MaxHealth;
        _health = _maxHealth;
        _damage = stat.Damage;
        _moveSpeed = stat.MoveSpeed;
        _isTargetToPlayer= stat.IsTargetToPlayer;
    }
    public void SetMaxHealth(float value)
    {
        _maxHealth = value;
    }

    public void SetHealth(float value)
    {
        _health = Mathf.Max(0f, value);
    }

    public void AddHealth(float value)
    {
        _health = Mathf.Max(0f, _health + value);
    }

    public void SetDamage(float value)
    {
        _damage = Mathf.Max(0f, value);
    }

    public void SetMoveSpeed(float value)
    {
        _moveSpeed = Mathf.Max(0f, value);
    }
}
