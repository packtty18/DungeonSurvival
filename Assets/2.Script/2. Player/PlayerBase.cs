using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    //플레이어의 스크립트를 관리 및 유통
    private PlayerInput _input;
    private PlayerStat _stat;
    private PlayerHealth _health;
    private PlayerMove _move;
    private PlayerAttack _attack;
    private PlayerLevel _level;

    public PlayerInput Input => _input;
    public PlayerStat Stat => _stat;
    public PlayerHealth Health =>_health;
    public PlayerMove Move => _move;
    public PlayerAttack Attack => _attack;
    public PlayerLevel Level => _level;

    public bool IsReady = false;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _stat = GetComponent<PlayerStat>();
        _health = GetComponent<PlayerHealth>();
        _move = GetComponent<PlayerMove>();
        _attack = GetComponent<PlayerAttack>();
        _level = GetComponent<PlayerLevel>();
        Init();
    }

    public void Init()
    {
        _input.Init(this);
        _stat.Init(this);
        _health.Init(this);
        _move.Init(this);
        _attack.Init(this);
        _level.Init(this);
        IsReady = true;
    }

}
