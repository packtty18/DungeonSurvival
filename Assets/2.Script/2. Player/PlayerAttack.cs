using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{
    //플레이어의 조작을 통한 기본 공격
    //공격범위, 공격속도, 공격발동 관리
    [SerializeField] private PlayerStat _stat;

    [SerializeField] private Transform _attackTransform;
    [SerializeField] private GameObject _attackObjectProto;

    private float _damage => _stat.Damage;
    private float _coolTime => _stat.AttackDelay;

    private float _coolTimer;


    private void Start()
    {
        _stat = GetComponent<PlayerStat>();
        _coolTimer = _coolTime;
    }

    private void Update()
    {
        // 쿨타임 감소
        if (_coolTimer > 0f)
            _coolTimer -= Time.deltaTime;

        // 공격 가능 여부
        if (_coolTimer <= 0f)
        {
            Attack();
            _coolTimer = _coolTime;
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        if(FactoryManager.IsManagerExist())
        {
            AttackFactory factory = FactoryManager.Instance.GetFactory<AttackFactory>();
            factory.MakeDamageObject(EAttackType.PlayerDefualt, transform.position, _attackTransform.rotation);

        }
        else
        {
            Instantiate(_attackObjectProto, transform.position, _attackTransform.rotation);
        }
            
    }

    


}
