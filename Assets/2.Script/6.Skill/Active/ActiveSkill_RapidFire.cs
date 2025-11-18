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
        CoolTimer = Data.levelStats[Level - 1].Cooldown;
    }

    private IEnumerator FireRoutine(Vector3 target)
    {
        ActiveSkillLevelData stat = Data.levelStats[Level - 1];
        int bulletCount = stat.AttackCount;
        

        AttackFactory factory = FactoryManager.Instance.GetFactory<AttackFactory>();

        for (int i = 0; i < bulletCount; i++)
        {
            Vector3 origin = transform.position;
            Vector3 direction = (target - origin).normalized;
            SoundManager.Instance.CreateSFX(ESFXType.Bullet, transform.position);
            Vector3 dir = (target - origin).normalized;

            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion rot = Quaternion.Euler(0f, 0f, rotationZ);
            
            Bullet bullet = factory.MakeDamageObject(EPlayerAttackType.Bullet, origin, rot)
                                  .GetComponent<Bullet>();

            bullet.Init(dir, stat.DamageRate * _stat.Damage, bulletSpeed, bulletLifetime);
            yield return new WaitForSeconds(delayBetweenBullets); // 총알 사이 딜레이
        }

        firingCoroutine = null;
    }

}
