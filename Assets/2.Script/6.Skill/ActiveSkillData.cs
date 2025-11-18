using UnityEngine;


[System.Serializable]
public struct ActiveSkillLevelData
{
    public int AttackCount;       // 발사 수
    public float Cooldown;        // 쿨타임
    public float Duration;        // 상태이상 시간/장판 지속 등
    public float DamageRate;
}

[CreateAssetMenu(fileName = "SkillData", menuName = "Game/ActiveSkillData")]
public class ActiveSkillData : ScriptableObject
{
    public EActiveSkillType skillType;
    public int maxLevel = 5;
    public ActiveSkillLevelData[] levelStats;
}
