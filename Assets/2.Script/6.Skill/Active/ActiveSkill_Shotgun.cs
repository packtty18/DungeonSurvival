using UnityEngine;

public class ActiveSkill_Shotgun : ActiveBase
{
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float bulletLifetime = 2f;
    
    public override void Activate(Vector3 target)
    {
        if (!IsReady)
            return;

        ActiveSkillLevelData stat = Data.levelStats[Level - 1];
        int bulletCount = stat.AttackCount;
        float angleSpread = 30f;

        Vector3 origin = transform.position;
        Vector3 baseDir = (target - origin).normalized;

        SoundManager.Instance.CreateSFX(ESFXType.Bullet, transform.position);
        AttackFactory factory = FactoryManager.Instance.GetFactory<AttackFactory>();

        for (int i = 0; i < bulletCount; i++)
        {
            // 퍼질 각도 계산
            float t = (bulletCount == 1) ? 0.5f : (float)i / (bulletCount - 1);
            float angle = Mathf.Lerp(-angleSpread * 0.5f, angleSpread * 0.5f, t);

            // 방향 회전 적용
            Vector3 dir = Quaternion.Euler(0, 0, angle) * baseDir;

            // 총알이 위(+Y)를 향하도록 보정
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion rot = Quaternion.Euler(0, 0, rotZ);

            // 생성
            Bullet bullet = factory
                .MakeDamageObject(EPlayerAttackType.Bullet, origin, rot)
                .GetComponent<Bullet>();

            // 초기화
            bullet.Init(dir, stat.DamageRate * _stat.Damage, bulletSpeed, bulletLifetime);
        }

        CoolTimer = stat.Cooldown;

        Debug.Log($"Shotgun Fired! Bullets: {bulletCount}, Cooldown: {stat.Cooldown}");
    }
}
