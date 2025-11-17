using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Attack/Ranged")]
public class RangedAttackSO : AttackPatternSO
{
    public GameObject BulletPrefab;
    public float Speed = 5f;

    public override void Execute(EnemyAttack owner)
    {
        Vector2 dir = (owner.Target.transform.position - owner.transform.position).normalized;

        GameObject bullet = Instantiate(
            BulletPrefab,
            owner.transform.position,
            Quaternion.FromToRotation(Vector2.right, dir)
        );

        //if (bullet.TryGetComponent(out Bullet b))
        //{
        //    b.Init(dir, Speed, Damage);
        //}

        Debug.Log($"🔫 Ranged Attack fired");
    }
}
