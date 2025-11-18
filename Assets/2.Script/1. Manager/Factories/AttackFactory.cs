using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFactory : FactoryBase<EPlayerAttackType>
{
    //총알에 대한 생성을 담당
    //즉 BulletBase를 상속받는 클래스들 담당 생성

    [Header("프리팹")]
    [SerializeField] private GameObject _playerDefaultPrefab;
    


    protected override void RegisterPrefabs()
    {
        _prefabMap = new Dictionary<EPlayerAttackType, GameObject>
        {
            { EPlayerAttackType.Bullet, _playerDefaultPrefab },
            { EPlayerAttackType.Grenade, _playerDefaultPrefab },
            { EPlayerAttackType.Explosion, _playerDefaultPrefab },
        };
    }

    //전처리까지 해서 반환
    public GameObject MakeDamageObject(EPlayerAttackType type, Vector3 position, Quaternion rotation)
    {
        //여기서 풀에서 빼오기
        BaseDamageObject obj = CreateObject(type).GetComponent<BaseDamageObject>();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.OnSpawn();

        return obj.gameObject;
    }

}
