using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private PlayerBase _base;
    private PlayerStat _stat => _base.Stat;
    public float MaxHealth => _stat.MaxHealth;
    public float CurrentHealth => _stat.Health;


    public void Init(PlayerBase playerBase)
    {
        _base = playerBase;
    }

    public void OnHit(float amount)
    {
        //hp감소
        _stat.SetHealth(Mathf.Max(CurrentHealth - amount, 0));

        if(CurrentHealth <= 0)
        {
            OnDead();
        }

    }
    public void OnHeal(float amount)
    {
        //hp증가
        _stat.SetHealth(Mathf.Max(CurrentHealth + amount, MaxHealth));
    }

    public void OnDead()
    {
        //시스템적으로 게임 종료처리
        _base.Animator.SetBool("Ondead", true);
        _base.IsReady = false;
    }

    [ContextMenu("hit")]    
    
    public void DebugDamage()
    {
        OnHit(40);
    }

    
}
