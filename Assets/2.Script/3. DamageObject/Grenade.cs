using UnityEngine;

public class Grenade : BaseDamageObject
{
    [Header("Explosion")]
    [SerializeField] private GameObject _explosionPrefab;

    public Vector3 StartPos;
    public Vector3 TargetPos;
    public float Duration = 1f;
    public float Elapse = 0f;
    public float Height = 2f; // 포물선 최대 높이

    public void Launch(Vector3 target, float damage, float duration = 1f, float height = 2f)
    {
        SetDamage(damage);

        StartPos = transform.position;
        TargetPos = target;
        Duration = duration;
        Height = height;
        Elapse = 0f;

        SetState(new GrenadeCurveState());
    }

    public void Explode()
    {
        if (FactoryManager.IsManagerExist())
        {
            AttackFactory factory = FactoryManager.Instance.GetFactory<AttackFactory>();
            factory.MakeDamageObject(EPlayerAttackType.Explosion, transform.position, Quaternion.identity);
        }

        OnDespawn();
    }
}
