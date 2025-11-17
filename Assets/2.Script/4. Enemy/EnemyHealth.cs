using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private EnemyStat _stat;
    public float MaxHealth => _stat.MaxHealth;

    public float CurrentHealth => _stat.Health;

    public void OnDead()
    {
        gameObject.SetActive(false);
    }

    public void OnHeal(float amount)
    {
        _stat.SetHealth(Mathf.Max(CurrentHealth + amount, MaxHealth));
    }

    public void OnHit(float amount)
    {
        _stat.SetHealth(Mathf.Max(CurrentHealth - amount, 0));

        if (CurrentHealth <= 0)
        {
            OnDead();
        }
    }
}
