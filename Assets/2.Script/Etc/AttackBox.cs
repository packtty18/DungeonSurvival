using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private float damageMultiplier = 1f; // 주는 데미지 조정
    public float DamageMultiplier => damageMultiplier;

    public IAttackable Owner { get; private set; }

    private void Start()
    {
        Owner = GetComponent<IAttackable>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            return;
        }

        
        if (collision.TryGetComponent(out HitBox hitBox))
        {
            IHealth target = hitBox.Owner;
            if (target != null)
            {
                float finalDamage = Owner.Damage * hitBox.DamageMultiplier;
                target.OnHit(finalDamage);

                Debug.Log($"[HitBox] {collision.name} took {finalDamage} damage");
            }
        }
    }
}
