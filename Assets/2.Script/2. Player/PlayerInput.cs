using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; } = Vector2.zero;

    public bool IsinputFire { get; private set; } = false;
    
    private void Update()
    {
        Vector2 moveInput = Vector2.zero;
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector2(h, v).normalized;

        // 데스크톱: 키보드 입력
        // IsinputFire = Input.GetKey(); 마우스 클릭으로 대체할것

    }

}

