using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    private float _currentSpeed = 1;
    public float CurrentSpeed => _currentSpeed;

    public void Move(Vector2 direction)
    {
        Vector2 newPos = (Vector2)transform.position + direction.normalized * _currentSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    public Vector2 SetDirection()
    {
        throw new System.NotImplementedException();
    }
}
