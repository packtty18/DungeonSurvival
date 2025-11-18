using UnityEngine;

public abstract class ActiveBase : SkillBase
{
    public ActiveSkillData Data;
    protected PlayerStat _stat => Owner.Stat; 
    
    [SerializeField]protected float cooldownTimer = 0f;

    public bool IsReady => cooldownTimer <= 0f;

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
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= deltaTime;
        }
    }

    public abstract void Activate(Vector3 target);
}
