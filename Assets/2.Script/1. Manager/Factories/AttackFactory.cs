using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFactory : FactoryBase<EAttackType>
{
    //총알에 대한 생성을 담당
    //즉 BulletBase를 상속받는 클래스들 담당 생성

    [Header("프리팹")]
    [SerializeField] private GameObject _playerDefaultPrefab;
    


    protected override void RegisterPrefabs()
    {
        _prefabMap = new Dictionary<EAttackType, GameObject>
        {
            { EAttackType.PlayerDefualt, _playerDefaultPrefab },
            //{ EProjectileType.PlayerSub, _playerSubPrefab },
            //{ EProjectileType.PlayerCurve, _playerCurvePrefab },
            //{ EProjectileType.PlayerBezier, _playerBezierPrefab },
            //{ EProjectileType.PlayerSpiral, _playerSpiralPrefab },
            //{ EProjectileType.PlayerBomb, _playerBombPrefab },
            //{ EProjectileType.EnemyDefault, _enemyDefaultPrefab }
        };
    }

    //전처리까지 해서 반환
    public GameObject MakeDamageObject(EAttackType type, Vector3 position, Quaternion rotation)
    {
        //여기서 풀에서 빼오기
        BaseDamageObject bullet = CreateObject(type).GetComponent<BaseDamageObject>();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.OnSpawn();
        bullet.gameObject.SetActive(true);
        return bullet.gameObject;
        return null;
    }

}
