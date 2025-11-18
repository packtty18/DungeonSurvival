using UnityEngine;

public abstract class ActiveBase : SkillBase
{
    public ActiveSkillData Data;
    protected PlayerStat _stat => Owner.Stat; 
    
    public float CoolTimer = 0f;

    public bool IsReady => CoolTimer <= 0f;

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
        if (CoolTimer > 0f)
        {
            CoolTimer -= deltaTime;
        }
    }

    public abstract void Activate(Vector3 target);
}
