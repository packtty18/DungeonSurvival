using System;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour, IMovable
{
    private EnemyBase _base;
    private EnemyStat _stat => _base.Stat;
    private EnemyAnimation _animation => _base.Animation;

    public float CurrentSpeed => _stat.MoveSpeed;
    public Vector2 CurrentDirection => _currentDirection;

    [SerializeField] private Vector2 _currentDirection;
    [Header("Knockback Settings")]
    [SerializeField] private float knockbackForce = 4f;
    [SerializeField] private float knockbackDuration = 0.15f;

    private Vector2 _knockbackVelocity;
    private float _knockbackTimer;

    public void Init(EnemyBase enemyBase)
    {
        //초기화 로직
        _base = enemyBase;
    }

    private void Update()
    {
        if (_base == null || !_base.IsReady)
        {
            return;
        }
        OnKnockBack();
        SetDirection(GetNextDirection());
        Move();
        SetMoveAnimation();
    }

    private void OnKnockBack()
    {
        if (_knockbackTimer > 0)
        {
            _knockbackTimer -= Time.deltaTime;
            transform.position += (Vector3)(_knockbackVelocity * Time.deltaTime);

            if (_knockbackTimer <= 0)
                _knockbackVelocity = Vector2.zero;

            return; 
        }
    }

    protected virtual Vector2 GetNextDirection()
    {
        if (_stat.IsTargetToPlayer && GameManager.IsManagerExist())
        {
            GameObject player = GameManager.Instance.Player;
            Transform target = player.transform;

            return (target.position - transform.position).normalized;
        }

        return _currentDirection;
    }
    private void SetMoveAnimation()
    {
        // Flip
        if (CurrentDirection.x < -0.01f)
            _animation.SetSpriteFlip(true);
        else if (CurrentDirection.x > 0.01f)
            _animation.SetSpriteFlip(false);
    }

    public void Move()
    {
        transform.position = (Vector2)transform.position + CurrentSpeed * CurrentDirection *Time.deltaTime;
    }

    public void SetDirection(Vector2 direction)
    {
        _currentDirection = direction;
    }

    public void ApplyKnockback()
    {
        Vector2 reverse = -CurrentDirection;
        _knockbackVelocity = reverse * knockbackForce;
        _knockbackTimer = knockbackDuration;
    }
}
