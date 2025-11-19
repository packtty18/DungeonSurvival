using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    //주어진 아이템을 확률로 반환하여 팩토리를 사용한 생성까지 담당
    [SerializeField] private EItemType[] _targets;
    [SerializeField] private float[] _weights;


    [ContextMenu("Item Drop")]
    public void DebugSpanw()
    {
        for(int i =0;i< 10; i++)
        {
            SpawnRandomItem();
        }
    }
    public void SpawnRandomItem()
    {
        if (_targets == null || _targets.Length != _weights.Length)
        {
            return;
        }
        EItemType target = StaticMethod.WeightedRandom(_targets, _weights);
        if(target == EItemType.None)
        {
            return;
        }
        if(!FactoryManager.IsManagerExist())
        {
            return;
        }

        ItemFactory factory = FactoryManager.Instance.GetFactory<ItemFactory>();
        factory.MakeItemObject(target, transform.position , transform.rotation);
        Debug.Log($"[ItemDropper] : craete {target.ToString()}");
    }
}
