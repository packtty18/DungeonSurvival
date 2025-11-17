using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private PlayerBase _base;
    [Header("Runtime Stats")]
    [SerializeField] private int _level;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _regenerationHealth;
    [SerializeField] private float _armorRate;
    [SerializeField] private float _evasionRate;
    [SerializeField] private float _attackDelay;

    [Header("Skill Stats")]
    [SerializeField] private float _skillSizeMultiplierRate;
    [SerializeField] private float _skillLiveTimeMultiplierRate;
    [SerializeField] private float _skillSelectCount;

    [Header("Item / Reward Stats")]
    [SerializeField] private float _itemAcquisitionRadius;
    [SerializeField] private float _expMultiplierRate;
    [SerializeField] private float _treasureBoxDropRate;

    [Header("Base Stat SO")]
    [SerializeField] private PlayerStatSO _baseStat;

    public int Level => _level;
    public float MaxHealth => _maxHealth;
    public float Health => _health;
    public float Damage => _damage;
    public float MoveSpeed => _moveSpeed;
    public float RegenerationHealth => _regenerationHealth;
    public float ArmorRate => _armorRate;
    public float EvasionRate => _evasionRate;
    public float AttackDelay => _attackDelay;

    public float SkillSizeMultiplierRate => _skillSizeMultiplierRate;
    public float SkillLiveTimeMultiplierRate => _skillLiveTimeMultiplierRate;
    public float SkillSelectCount => _skillSelectCount;

    public float ItemAcquisitionRadius => _itemAcquisitionRadius;
    public float ExpMultiplierRate => _expMultiplierRate;
    public float TreasureBoxDropRate => _treasureBoxDropRate;

    public void Init(PlayerBase playerBase)
    {
        _base = playerBase; 
        if (_baseStat != null)
        {
            ApplyBaseStat(_baseStat);
        }
    }

    private void ApplyBaseStat(PlayerStatSO stat)
    {
        _level = stat.Level;
        _maxHealth = stat.MaxHealth;
        _health = _maxHealth;
        _regenerationHealth = stat.RegenerationHealth;
        _damage = stat.Damage;
        _armorRate = stat.ArmorRate;
        _evasionRate = stat.EvasionRate;
        _moveSpeed = stat.MoveSpeed;
        _attackDelay = stat.AttackDelay;

        _skillSizeMultiplierRate = stat.SkillSizeMultiplierRate;
        _skillLiveTimeMultiplierRate = stat.SkillLiveTimeMultiplierRate;
        _skillSelectCount = stat.SkillSelectCount;

        _itemAcquisitionRadius = stat.ItemAcquisitionRadius;
        _expMultiplierRate = stat.ExpMultiplierRate;
        _treasureBoxDropRate = stat.TreasureBoxDropRate;
    }

    public void SetLevel(int level)
    {
        _level = level;
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
    public void SetArmorRate(float value)
    {
        _armorRate = Mathf.Clamp01(value);
    }

    public void SetEvasionRate(float value)
    {
        _evasionRate = Mathf.Clamp01(value);
    }

    public void SetAttackSpeed(float value)
    {
        _attackDelay = Mathf.Max(0f, value);
    }

    public void SetSkillSizeMultiplierRate(float value)
    {
        _skillSizeMultiplierRate = Mathf.Max(0f, value);
    }

    public void SetSkillLiveTimeMultiplierRate(float value)
    {
        _skillLiveTimeMultiplierRate = Mathf.Max(0f, value);
    }

    public void SetSkillSelectCount(float value)
    {
        _skillSelectCount = Mathf.Max(1f, value);
    }

    public void SetItemAcquisitionRadius(float value)
    {
        _itemAcquisitionRadius = Mathf.Max(0f, value);
    }

    public void SetExpMultiplierRate(float value)
    {
        _expMultiplierRate = Mathf.Max(0f, value);
    }

    public void SetTreasureBoxDropRate(float value)
    {
        _treasureBoxDropRate = Mathf.Clamp01(value);
    }

  
    
}
