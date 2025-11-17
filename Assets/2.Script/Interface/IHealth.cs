using System;

public interface IHealth 
{
    //최대 체력과 현재 체력
    float MaxHealth { get; }
    float CurrentHealth { get; }

    //피격
    void OnHit(float amount);

    //회복
    void OnHeal(float amount);

    //사망식
    void OnDead();

}
