using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    //플레이어의 스크립트를 관리 및 유통
    private PlayerInput _input;
    private PlayerStat _stat;
    private PlayerHealth _health;
    private PlayerMove _move;
    private PlayerLevel _level;
    private PlayerSkill _skill;
    private Animator _animator;
    public PlayerInput Input => _input;
    public PlayerStat Stat => _stat;
    public PlayerHealth Health =>_health;
    public PlayerMove Move => _move;
    public PlayerLevel Level => _level;
    public PlayerSkill Skill => _skill;
    public Animator Animator => _animator;

    public bool IsReady = false;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _stat = GetComponent<PlayerStat>();
        _health = GetComponent<PlayerHealth>();
        _move = GetComponent<PlayerMove>();
        _level = GetComponent<PlayerLevel>();
        _skill = GetComponent<PlayerSkill>();
        _animator = GetComponent<Animator>();
        
        Init();
    }

    public void Init()
    {
        _input?.Init(this);
        _stat?.Init(this);
        _health?.Init(this);
        _move?.Init(this);
        _level?.Init(this);
        _skill?.Init(this);
        _animator.SetBool("OnDead", false);
        SetCollider(true);
        IsReady = true;
    }

    public void SetCollider(bool active)
    {
        GetComponent<Collider2D>().enabled = active;
    }

}
