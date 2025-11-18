using UnityEngine;

public abstract class ActiveBase : MonoBehaviour
{
    public ActiveSkillData Data;
    public int Level { get; private set; } = 1;
    protected float cooldownTimer = 0f;

    public bool IsReady => cooldownTimer <= 0f;

    public virtual void Init(ActiveSkillData data)
    {
        Data = data;
        Level = 1;
        cooldownTimer = 0f;
    }

    public void LevelUp()
    {
        if (Level < Data.maxLevel)
        {
            Level++;
            Debug.Log($"{Data.skillType} Level Up! New Level: {Level}");
        }
    }

    public virtual void TickCooldown(float deltaTime)
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= deltaTime;
    }

    public abstract void Activate(Vector3 target);
}
