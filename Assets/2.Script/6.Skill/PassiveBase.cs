using UnityEngine;

public abstract class PassiveBase : MonoBehaviour
{
    public PassiveSkillData Data;
    public int Level { get; private set; } = 1;

    public virtual void Init(PassiveSkillData data)
    {
        Data = data;
        Level = 1;
        Apply();
    }

    public void LevelUp()
    {
        if (Level < Data.maxLevel)
        {
            Level++;
            Apply();
        }
    }

    public abstract void Apply(); // PlayerStat에 적용
}
