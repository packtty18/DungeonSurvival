using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStat", menuName = "Game/PlayerStat")]
public class PlayerStatSO : ScriptableObject
{
    [Header("Basic Stats")]
    public int Level = 1;
    public float MaxHealth = 100;
    public float RegenerationHealth = 0.1f;      // 초당 회복
    public float Damage = 10f;                   // 데미지
    public float ArmorRate = 0f;                 // 방어율
    public float EvasionRate = 0.2f;             // 회피율
    public float MoveSpeed = 1f;                 // 이동속도
    public float AttackDelay = 1f;               // 공격속도

    [Header("Skill Stats")]
    public float SkillSizeMultiplierRate = 0f;     // 스킬 크기 증폭율
    public float SkillLiveTimeMultiplierRate = 0f; // 스킬 지속시간 증폭율
    public float SkillSelectCount = 2;             // 레벨업 시 제시 스킬 개수

    [Header("Item / Reward Stats")]
    public float ItemAcquisitionRadius = 2f;      // 아이템 획득 반경
    public float ExpMultiplierRate = 1.5f;        // 경험치 증폭률
    public float TreasureBoxDropRate = 0.2f;      // 상자 드롭 확률
}
