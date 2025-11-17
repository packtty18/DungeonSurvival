using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour
{
    [Header("HitBox Settings")]
    [SerializeField] private float damageMultiplier = 1f; // 받는 데미지 조정
    public float DamageMultiplier => damageMultiplier;

    // 피격 주체
    public IHealth Owner { get; private set; }

    public void Initialize(IHealth owner)
    {
        Owner = owner;
    }
}
