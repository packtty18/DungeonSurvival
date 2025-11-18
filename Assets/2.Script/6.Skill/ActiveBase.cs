using UnityEngine;

public abstract class ActiveBase : SkillBase
{
    public ActiveSkillData Data;
    protected PlayerStat _stat => Owner.Stat; 
    
    [SerializeField]protected float _coolTimer = 0f;

    public bool IsReady => _coolTimer <= 0f;

    public override void Init()
    {
        base.Init();
    }

    public override void LevelUp()
    {
        if (Level < Data.maxLevel)
        {
            SetLevel(Level+1);
            Debug.Log($"{Data.skillType} Level Up! New Level: {Level}");
        }
    }

    public virtual void TickCooldown(float deltaTime)
    {
        if (_coolTimer > 0f)
        {
            _coolTimer -= deltaTime;
        }
    }

    public abstract void Activate(Vector3 target);
}
