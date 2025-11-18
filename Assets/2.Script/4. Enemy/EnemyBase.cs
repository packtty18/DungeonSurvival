using UnityEngine;

public class EnemyBase : MonoBehaviour, IPoolable
{
    //전체적인 에너미 스크립트 관리 및 스폰 및 풀링
    private EnemyStat _stat;
    private EnemyHealth _health;
    private EnemyMove _move;
    private EnemyAnimation _animation;

    public EnemyStat Stat => _stat;
    public EnemyHealth Health => _health;
    public EnemyMove Move => _move;
    public EnemyAnimation Animation =>  _animation;

    [SerializeField] private Collider2D[] _collider;


    public bool IsReady = false;

    [Header("ExplosionPrefab")]
    public GameObject ExplosionPrefabs;

    private void Awake()
    {
        _stat = GetComponent<EnemyStat>();
        _health = GetComponent<EnemyHealth>();
        _move = GetComponent<EnemyMove>();
        _animation = GetComponent<EnemyAnimation>();
        _collider = GetComponentsInChildren<Collider2D>();
    }

    [ContextMenu("OnSpawn")]
    public void OnSpawn()
    {
        _stat?.Init(this);
        _health?.Init(this);
        _move?.Init(this);
        _animation?.Init(this);

        SetColliderEnable(true);

        IsReady = true;
        gameObject.SetActive(true);
    }


    public void OnDespawn()
    {
        //사망
        IsReady = false;
        
        gameObject.SetActive(false);
    }

    public void SetColliderEnable(bool active)
    {
        foreach (var collider in _collider)
        {
            collider.enabled = active;
        }
    }

    public void MakeExplosionEffect()
    {
        if (ExplosionPrefabs == null)
            return;
        GameObject effect = Instantiate(ExplosionPrefabs, transform.position, Quaternion.identity);

        if (effect.TryGetComponent<CameraShake>(out CameraShake shaker))
        {
            shaker.StartShake();
        }

        if (SoundManager.IsManagerExist())
        {
            SoundManager.Instance.CreateSFX(ESFXType.Explosion, transform.position, effect.transform);
        }

    }
}
