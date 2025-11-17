using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    [Header("Component")]
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerStat _stat;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    [Header("MoveStat")]
    [SerializeField] private Vector2 _currentDirection = Vector2.zero;

    public float CurrentSpeed => _stat.MoveSpeed;
    public Vector2 CurrentDirection => _currentDirection;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _stat = GetComponent<PlayerStat>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
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
        _animator.SetBool("IsMove", isMoving);
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
