using UnityEngine;

public abstract class ItemBase : MonoBehaviour , IPoolable
{
    //충돌처리, 풀링처리 //효과는 상속해서
    protected PlayerBase _player;
    public float Value;

    public void OnSpawn()
    {
        Init();
    }

    protected virtual void Init()
    {
        if(!GameManager.IsManagerExist())
        {
            _player = GameObject.FindWithTag("Player").GetComponent<PlayerBase>();
        }
        else
        {
            _player = GameManager.Instance.Player.GetComponent<PlayerBase>();
        }
           
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    //아이템의 효과
    public abstract void OnEffect();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 아이템을 획득
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        OnEffect();
        OnDespawn();
    }

}
