using UnityEngine;

public class CooltimeSpawner : SpanwerBase
{
    [Header("Enemy Prefabs")]
    [SerializeField] private EEnemyType[] _spawnType;
    [SerializeField] private float[] _spawnWeight;


    //쿨타임형 스포너
    [Header("FireCoolTime")]
    [SerializeField] private float _coolTime = 2f;
    private float _coolTimer;

    [SerializeField] private float _minCoolTime = 1.0f;
    [SerializeField] private float _maxCoolTime = 3.0f;

    private void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        _coolTime = GetRandomCoolTime(_minCoolTime, _maxCoolTime);
    }
    
    protected override void Spawn()
    {
        _coolTimer += Time.deltaTime;

        if (_coolTimer >= _coolTime)
        {
            _coolTimer = 0f;

            //스폰할때마다 스폰시간 재설정
            _coolTime = GetRandomCoolTime(_minCoolTime, _maxCoolTime);

            if (_spawnType == null || _spawnType.Length != _spawnWeight.Length)
                return;

            EEnemyType target = StaticMethod.WeightedRandom(_spawnType, _spawnWeight);

            if (!FactoryManager.IsManagerExist())
            {
                return;
            }

            EnemyFactory factory = FactoryManager.Instance.GetFactory<EnemyFactory>();
            EnemyBase enemy = factory.MakeEnemy(target, _spawnTrasnform[Random.Range(0, _spawnTrasnform.Length)].transform.position).GetComponent<EnemyBase>();

            //enemy.SetStatMultiplier(1 + (0.2f * SaveManager.Instance.GetSaveData().CurrentPhase));
        }
    }
   

    private float GetRandomCoolTime(float min, float max)
    {
        return Random.Range(min, max);
    }
}


