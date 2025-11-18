using UnityEngine;

public interface IDamageObjectState
{
    void Enter(BaseDamageObject obj);
    void Tick(float deltaTime);
    void Exit();
}