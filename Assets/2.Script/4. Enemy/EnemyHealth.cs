using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private EnemyStat _stat;
    [SerializeField] private Animator _animator;
    public float MaxHealth => _stat.MaxHealth;

    public float CurrentHealth => _stat.Health;

    private void Start()
    {
        _stat = GetComponent<EnemyStat>();
        _animator = GetComponent<Animator>();
    }

    public void OnDead()
    {
        _animator.SetBool("OnDead", true);
        // 3초 후에 비활성화
        StartCoroutine(DeactivateAfterSeconds(3f));
    }

    private IEnumerator DeactivateAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
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
        else
        {
            _animator.SetTrigger("OnHit");
        }
    }
}
