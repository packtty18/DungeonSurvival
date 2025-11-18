using UnityEngine;

public abstract class PassiveBase : SkillBase
{
    public PassiveSkillData Data;

    public override void Init()
    {
        base.Init();
        Apply();
    }

    public override void LevelUp()
    {
        if (Level < Data.maxLevel)
        {
            SetLevel(Level+1);
            Apply();
        }
    }

    public abstract void Apply();
}
