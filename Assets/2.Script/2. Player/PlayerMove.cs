using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    [Header("Component")]
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerStat _stat;

    [Header("MoveStat")]
    [SerializeField] private Vector2 _currentDirection = Vector2.zero;

    public float CurrentSpeed => _stat.MoveSpeed;
    public Vector2 CurrentDirection => _currentDirection;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _stat = GetComponent<PlayerStat>();
    }

    private void Update()
    {
        SetDirection(_input.MoveDirection);
        Move();
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
