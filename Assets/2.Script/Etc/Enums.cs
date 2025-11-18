public enum SpawnType
{
    None,   //누구의 편도 아님 => 중립
    Player, //플레이어의 진영임 
    Enemy,  //적의 진영임
}

public enum EItemType
{
    None,
    Exp,
    Treasure,
}

public enum EEnemyType
{
    Mushroom,
    Goblin,
    Fly,
    Skeleton,
    Treasure,
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

public enum EPlayerAttackType
{
    Bullet,
    Grenade,
    Explosion

}

public enum EEnemyAttackType
{
    EnemyDefualt,   
}

public enum EFactoryType
{
    PlayerAttack,
    EnemyAttack,
    Enemy,
    Item
}

public enum EuttonType
{
    Attack,
    Bomb,
    DamageUp
}

public enum EActiveSkillType
{
    None,
    Shotgun,
    RapidFire,
    FlameShot,
    ElectricShot,
    IceShot,
    Grenade,
    Molotov
}

public enum EPassiveSkillType
{ 
    None,
    AttackUp,
    
}


