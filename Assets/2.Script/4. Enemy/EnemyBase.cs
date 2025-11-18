using UnityEngine;

public class EnemyBase : MonoBehaviour, IPoolable
{
    //전체적인 에너미 스크립트 관리 및 스폰 및 풀링
    private EnemyStat _stat;
    private EnemyHealth _health;
    private EnemyMove _move;
    private EnemyAttack _attack;
    private EnemyAnimation _animation;

    public EnemyStat Stat => _stat;
    public EnemyHealth Health => _health;
    public EnemyMove Move => _move;
    public EnemyAttack Attack => _attack;
    public EnemyAnimation Animation =>  _animation;

    public bool IsReady = false;

    private void Awake()
    {
        _stat = GetComponent<EnemyStat>();
        _health = GetComponent<EnemyHealth>();
        _move = GetComponent<EnemyMove>();
        _attack = GetComponent<EnemyAttack>();
        _animation = GetComponent<EnemyAnimation>();
    }

    [ContextMenu("OnSpawn")]
    public void OnSpawn()
    {
        _stat?.Init(this);
        _health?.Init(this);
        _move?.Init(this);
        _attack?.Init(this);
        _animation?.Init(this);
        IsReady = true;
    }


    public void OnDespawn()
    {
        //사망
        IsReady = false;
        gameObject.SetActive(false);
    }

    
}
