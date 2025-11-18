using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : FactoryBase<EItemType>
{
    //총알에 대한 생성을 담당
    //즉 BulletBase를 상속받는 클래스들 담당 생성

    [Header("프리팹")]
    [SerializeField] private GameObject _expPrefab;
    [SerializeField] private GameObject _treasurePrefab;
    protected override void RegisterPrefabs()
    {
        _prefabMap = new Dictionary<EItemType, GameObject>
        {
            { EItemType.Exp, _expPrefab },
            { EItemType.Treasure, _treasurePrefab },

        };
    }

    //전처리까지 해서 반환
    public GameObject MakeItemObject(EItemType type, Vector3 position, Quaternion rotation)
    {
        //여기서 풀에서 빼오기
        ItemBase item = CreateObject(type).GetComponent<ItemBase>();
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.gameObject.SetActive(true);
        item.OnSpawn();
        return item.gameObject;
    }

}
