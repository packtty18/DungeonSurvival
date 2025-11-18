using System;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    [Header("Component")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private PlayerBase _base;
    private PlayerInput _input => _base.Input;
    private PlayerStat _stat => _base.Stat;

    [Header("MoveStat")]
    [SerializeField] private Vector2 _currentDirection = Vector2.zero;

    public float CurrentSpeed => _stat.MoveSpeed;
    public Vector2 CurrentDirection => _currentDirection;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(PlayerBase playerBase)
    {
        _base = playerBase;
       
    }

    private void Update()
    {
        if(_base == null || !_base.IsReady)
        {
            return;
        }   
        
        SetDirection(_input.MoveDirection);
        Move();
        SetMoveAnimation();
    }

    private void SetMoveAnimation()
    {
        // Flip
        if (CurrentDirection.x < -0.01f)
            _spriteRenderer.flipX = true;
        else if (CurrentDirection.x > 0.01f) 
            _spriteRenderer.flipX = false;

        // IsMove
        bool isMoving = CurrentDirection.magnitude > 0.01f;
        _base.Animator.SetBool("IsMove", isMoving);
    }


    public void Move()
    {
       
        Vector2 newPos = (Vector2)transform.position + _currentDirection.normalized * CurrentSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    public void SetDirection(Vector2 direction)
    {
        _currentDirection = direction;
    }
}
