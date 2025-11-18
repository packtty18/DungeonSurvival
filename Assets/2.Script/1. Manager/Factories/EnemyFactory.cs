using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : FactoryBase<EEnemyType>
{

    [Header("프리팹")]
    [SerializeField] private GameObject _mushroomPrefab;
    [SerializeField] private GameObject _goblinPrefab;
    [SerializeField] private GameObject _flyPrefab;
    [SerializeField] private GameObject _skeletonPrefab;
    [SerializeField] private GameObject _treasurePrefab;
    protected override void RegisterPrefabs()
    {
        _prefabMap = new Dictionary<EEnemyType, GameObject>
        {
            { EEnemyType.Mushroom, _mushroomPrefab },
            { EEnemyType.Goblin, _goblinPrefab },
            { EEnemyType.Fly, _flyPrefab },
            { EEnemyType.Skeleton, _skeletonPrefab },
            { EEnemyType.Treasure, _treasurePrefab }
        };
    }

    public GameObject MakeEnemy(EEnemyType type, Vector3 position)
    {
        EnemyBase enemy = CreateObject(type).GetComponent<EnemyBase>();

        enemy.transform.position = position;
        enemy.OnSpawn();
        return enemy.gameObject;
    }
}
