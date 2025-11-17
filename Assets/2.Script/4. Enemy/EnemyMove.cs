using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour, IMovable
{
    [SerializeField] private EnemyStat _stat;

    [SerializeField] private Vector2 _currentDirection;

    public float CurrentSpeed => _stat.MoveSpeed;
    public Vector2 CurrentDirection => _currentDirection;

    private void Start()
    {
        _stat = GetComponent<EnemyStat>();
    }

    private void Update()
    {
        SetDirection(GetNextDirection());
        Move();
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


    public void Move()
    {
        transform.position = (Vector2)transform.position + CurrentSpeed * CurrentDirection *Time.deltaTime;
    }

    public void SetDirection(Vector2 direction)
    {
        _currentDirection = direction;
    }
}
