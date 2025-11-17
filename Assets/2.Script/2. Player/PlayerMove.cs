using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    [Header("Component")]
    [SerializeField] private PlayerInput _input;

    [Header("MoveStat")]
    [SerializeField] private float _currentSpeed = 1;
    [SerializeField] private Vector2 _currentDirection = Vector2.zero;
    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        SetDirection(_input.MoveDirection);
        Move();
    }

    public void Move()
    {
        Vector2 newPos = (Vector2)transform.position + _currentDirection.normalized * _currentSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    public void SetDirection(Vector2 direction)
    {
        _currentDirection = direction;
    }
}
