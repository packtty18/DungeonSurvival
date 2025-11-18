using UnityEngine;
using System.Collections;

public class ActiveSkill_RapidFire : ActiveBase
{
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float bulletLifetime = 2f;
    [SerializeField] private float delayBetweenBullets = 0.1f; // 총알 사이 딜레이

    [SerializeField] private Coroutine firingCoroutine;

    public override void Activate(Vector3 target)
    {
        if (!IsReady)
            return;

        if (firingCoroutine != null)
            Owner.StopCoroutine(firingCoroutine);

        firingCoroutine = Owner.StartCoroutine(FireRoutine(target));
        cooldownTimer = Data.levelStats[Level - 1].Cooldown;
    }

    private IEnumerator FireRoutine(Vector3 target)
    {
        ActiveSkillLevelData stat = Data.levelStats[Level - 1];
        int bulletCount = stat.AttackCount;
        Vector3 origin = transform.position;
        Vector3 direction = (target - origin).normalized;

        AttackFactory factory = FactoryManager.Instance.GetFactory<AttackFactory>();

        for (int i = 0; i < bulletCount; i++)
        {
            Bullet bullet = factory.MakeDamageObject(EPlayerAttackType.Bullet, origin, Quaternion.identity)
                                .GetComponent<Bullet>();
            bullet.Init(direction, stat.DamageRate * _stat.Damage, bulletSpeed, bulletLifetime);

            yield return new WaitForSeconds(delayBetweenBullets); // 딜레이
        }

        
        firingCoroutine = null;
    }
}
