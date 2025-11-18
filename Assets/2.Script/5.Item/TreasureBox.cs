using UnityEngine;

public class TreasureBox : ItemBase
{
    protected override void Init()
    {
        OnEffect();
    }

    public override void OnEffect()
    {
        if(!FactoryManager.IsManagerExist())
        {
            return;
        }

        EnemyFactory factory = FactoryManager.Instance.GetFactory<EnemyFactory>();
        factory.MakeEnemy(EEnemyType.Treasure, transform.position);

        OnDespawn();
    }
}
