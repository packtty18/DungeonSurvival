using UnityEngine;

public class AttackBox : MonoBehaviour
{
    //공격 범위를 명시 + 데미지처리 필요
    public IAttackable Owner { get; private set; }

    private void Start()
    {
        Owner = GetComponentInParent<IAttackable>();
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
