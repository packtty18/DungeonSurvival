using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    //exp와 레벨업을 관리
    private PlayerBase _base;
    private PlayerStat _stat => _base.Stat;

    public void Init(PlayerBase playerBase)
    {
        _base = playerBase;
    }

    private void Update()
    {
        if (_base == null || !_base.IsReady)
            return;
    }

    public void AddExp(float value)
    {
        float gained = value * (1 + _stat.ExpMultiplierRate);
        _stat.SetCurrentExp(_stat.CurrentExp + gained);
        CheckExp();
    }

    private void CheckExp()
    {
        while (_stat.CurrentExp >= _stat.NextExp)
        {
            float overflow = _stat.CurrentExp - _stat.NextExp;
            LevelUp();
            _stat.SetNextExp(_stat.NextExp * 1.5f);
            _stat.SetCurrentExp(overflow);
        }
    }

    private void LevelUp()
    {
        _stat.SetLevel(_stat.Level + 1);

        Debug.Log($"⭐ Level Up! New Level: {_stat.Level}");
    }
}
