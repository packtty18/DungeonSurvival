public enum SpawnType
{
    None,   //누구의 편도 아님 => 중립
    Player, //플레이어의 진영임 
    Enemy,  //적의 진영임
}

public enum EItemType
{
    MoveSpeedUp,
    HealthUp,
    AttackSpeedUp
}

public enum EEnemyType
{
    Direction,
    Trace,
    Teleport,
    Boss
}

public enum EPlayerAIStateType
{
    Idle,
    Attack,
    Retreat
}

public enum EPlayerMoveState
{
    Idle,
    Chase,
    Retreat
}

public enum ESFXType
{ 
    GameOver,
    PlayerFire,
    Bomb,
    BombLoop,
    Explosion,
    ItemHeal,
    ItemAttackUp,
    ItemMoveUp,
    PlayerHit
}

public enum EAttackType
{
    PlayerDefualt,
    
}

public enum EFactoryType
{
    Bullet,
    Enemy,
    Item
}

public enum EuttonType
{
    Attack,
    Bomb,
    DamageUp
}
