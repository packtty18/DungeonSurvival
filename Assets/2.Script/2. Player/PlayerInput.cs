using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private PlayerBase _base;
    public Vector2 MoveDirection { get; private set; } = Vector2.zero;
    public Vector2 MouseWorldPosition { get; private set; } = Vector2.zero;
    //public bool IsInputAttack { get; private set; } = false;

    public void Init(PlayerBase playerBase)
    {
        _base = playerBase;
    }

    private void Update()
    {
        if (_base == null || !_base.IsReady)
        {
            return;
        }

        Vector2 moveInput = Vector2.zero;
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector2(h, v).normalized;

        MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //IsInputAttack = Input.GetMouseButtonDown(0);

        // 데스크톱: 키보드 입력
        // IsinputFire = Input.GetKey(); 마우스 클릭으로 대체할것

    }

}

