using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour
{
    public SpawnType Type;

    [SerializeField] private float _damageMultiplier = 1f;
    public float DamageMultiplier => _damageMultiplier;

    public IHealth Owner { get; private set; }
    private void Start()
    {
        // AttackBox는 보통 자식이므로 부모에서 IAttackable 검색
        Owner = GetComponentInParent<IHealth>();

        if (Owner == null)
            Debug.LogError($"[AttackBox] Owner(IAttackable) not found in parents! ({name})");
    }
}
