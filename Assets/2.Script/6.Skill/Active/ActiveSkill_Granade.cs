using UnityEngine;
using static UnityEngine.UI.Image;

public class ActiveSkill_Granade : ActiveBase
{
    public override void Activate(Vector3 target)
    {
        if (!IsReady) 
            return;

        ActiveSkillLevelData stat = Data.levelStats[Level - 1];
        int count = Mathf.FloorToInt(stat.AttackCount);
        float duration = stat.Duration;
        float cooldown = Mathf.Max(0.1f, stat.Cooldown);

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = Owner.transform.position;
            AttackFactory factory = FactoryManager.Instance.GetFactory<AttackFactory>();
            Grenade grenade = factory.MakeDamageObject(EPlayerAttackType.Grenade, spawnPos, Quaternion.identity).GetComponent<Grenade>();

            grenade.Launch(target, stat.DamageRate * _stat.Damage);

        }

        cooldownTimer = cooldown;
    }
}
