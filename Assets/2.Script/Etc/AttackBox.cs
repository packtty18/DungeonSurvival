using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public SpawnType type;
    [SerializeField] private float damageMultiplier = 1f;
    public float DamageMultiplier => damageMultiplier;

    public IAttackable Owner { get; private set; }

    private void Awake()
    {
        // AttackBox는 보통 자식이므로 부모에서 IAttackable 검색
        Owner = GetComponentInParent<IAttackable>();

        if (Owner == null)
            Debug.LogError($"[AttackBox] Owner(IAttackable) not found in parents! ({name})");
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            return;

        if (collision.TryGetComponent(out HitBox hitBox))
        {
            if (hitBox.type == type)
            {
                // 같은 진영이면 데미지 없음
                return;
            }

            IHealth target = hitBox.Owner;
            if (target != null)
            {
                float finalDamage = Owner.Damage * hitBox.DamageMultiplier * DamageMultiplier;

                target.OnHit(finalDamage);

                Debug.Log($"[AttackBox] {collision.name} took {finalDamage} damage");
            }
        }
    }
}
