using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    //적의 스프라이트 및 애니메이션 처리
    [SerializeField] private Transform _spriteObject;
    private SpriteRenderer _renderer;
    private Animator _animator;

    private void Awake()
    {
        if(_spriteObject == null)
        {
            _spriteObject = transform.GetComponentInChildren<SpriteRenderer>().transform;
        }
        _renderer = _spriteObject.GetComponent<SpriteRenderer>();
        _animator = _spriteObject.GetComponent<Animator>();
    }

    public void Init()
    {
        SetDead();
    }

    public void SetDead(bool isDead = false)
    {
        _animator.SetBool("OnDead", isDead);
    }

    public void SetOnHit()
    {
        _animator.SetTrigger("OnHit");
    }

    public void SetSpriteFlip(bool isLeft = false)
    {
        _renderer.flipX = isLeft;
    }

}
