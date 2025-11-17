using UnityEngine;


public abstract class BaseDamageObject : MonoBehaviour, IPoolable,IAttackable
{
    [SerializeField] private SpawnType ownerType;
    [SerializeField]private float _damage;
    public float Damage => _damage;
    public SpawnType OwnerType => ownerType;
    private void Start()
    {
        OnSpawn();
    }
    
    public void OnSpawn()
    {
        Init();
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    protected abstract void Init();

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void SetObjectType(SpawnType type)
    {
        ownerType = type;
    }
}
