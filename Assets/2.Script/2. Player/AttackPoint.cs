using UnityEngine;

public class AttackPoint : MonoBehaviour
{

    private PlayerInput _input;
    [SerializeField] private GameObject _owner;
    [SerializeField] private float _offset = 2f;

    private void Start()
    {
        _input = GetComponentInParent<PlayerInput>();
    }
    private void Update()
    {
        UpdateAttackPoint();
    }

    private void UpdateAttackPoint()
    {
        Vector2 playerPos = _owner.transform.position;
        Vector2 mousePos = _input.MouseWorldPosition;

        Vector2 direction = mousePos - playerPos;
        float distance = direction.magnitude;

        Vector2 target;

        if (distance <= _offset)
        {
            // 공격범위 안: 마우스 위치
            target = mousePos;
        }
        else
        {
            // 공격범위 밖: 최대 거리 방향
            target = playerPos + direction.normalized * _offset;
        }

        // 월드 좌표 적용
        transform.position = target;

        // 회전
        if (direction != Vector2.zero)
        {
            Vector2 lookDir = target - playerPos; // offset 거리 기준 방향
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // 위쪽 기준
        }
    }

}
