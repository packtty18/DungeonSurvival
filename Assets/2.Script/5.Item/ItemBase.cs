using UnityEngine;

public abstract class ItemBase : MonoBehaviour , IPoolable
{
    //충돌처리, 풀링처리 //효과는 상속해서
    
    public void OnSpawn()
    {
        throw new System.NotImplementedException();
    }
    public void OnDespawn()
    {
        throw new System.NotImplementedException();
    }

    //아이템의 효과
    public abstract void OnEffect();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 아이템을 획득

    }

}
