using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private PlayerStat _stat;
    public float MaxHealth => _stat.MaxHealth;
    public float CurrentHealth => _stat.Health;


    private void Start()
    {
        _stat = GetComponent<PlayerStat>();
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
        //
        gameObject.SetActive(false);
    }

    [ContextMenu("hit")]    
    
    public void DebugDamage()
    {
        OnHit(40);
    }

    
}
