using UnityEngine;

public class MovableDamageObject : BaseDamageObject, IMovable
{
    private float _currentSpeed;
    private Vector2 _currentDirection;

    public float CurrentSpeed => _currentSpeed;
    public Vector2 CurrentDirection => _currentDirection;
    protected override void Init()
    {
        Debug.Log("Movable DamageObject Init");
    }


    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = (Vector2)transform.position + CurrentSpeed * CurrentDirection * Time.deltaTime;
    }

    public void SetDirection(Vector2 direction)
    {
        _currentDirection = direction;
    }

    public void SetSpeed(float value)
    {
        _currentSpeed = value;
    }

    
}
