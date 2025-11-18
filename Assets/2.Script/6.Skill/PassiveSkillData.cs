using UnityEngine;


[System.Serializable]
public struct PassiveSkillLevelData
{
    public float Value;
}

[CreateAssetMenu(fileName = "SkillData", menuName = "Game/PassiveSkillData")]
public class PassiveSkillData : ScriptableObject
{
    public EPassiveSkillType skillType;
    public int maxLevel = 5;
    public PassiveSkillLevelData[] levelStats;
}
