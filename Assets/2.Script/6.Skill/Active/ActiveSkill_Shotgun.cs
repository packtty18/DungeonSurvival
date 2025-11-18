using UnityEngine;

public class ActiveSkill_Shotgun : ActiveBase
{
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float bulletLifetime = 2f;
    
    public override void Activate(Vector3 target)
    {
        if (!IsReady)
        {
            return;
        }
            

        ActiveSkillLevelData stat = Data.levelStats[Level - 1];
        int bulletCount = stat.AttackCount;
        float angleSpread = 30f; // 부채꼴 각도

        Vector3 origin = transform.position;
        Vector3 direction = (target - origin).normalized;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = -angleSpread / 2 + i * (angleSpread / (bulletCount - 1));
            Vector3 dir = Quaternion.Euler(0, 0, angle) * direction;
            AttackFactory factory = FactoryManager.Instance.GetFactory<AttackFactory>();
            Bullet bullet = factory.MakeDamageObject(EPlayerAttackType.Bullet,origin,Quaternion.identity).GetComponent<Bullet>();
            bullet.Init(dir, stat.DamageRate * _stat.Damage, bulletSpeed, bulletLifetime);
        }

        cooldownTimer = stat.Cooldown;

        Debug.Log($"Shotgun Fired! Bullets: {bulletCount}, Cooldown: {stat.Cooldown}");
    }
}
