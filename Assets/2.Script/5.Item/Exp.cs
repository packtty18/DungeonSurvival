using UnityEngine;

public class Exp : ItemBase
{
    private const float DEFAULT_EXP_VALUE = 10;

    protected override void Init()
    {
        base.Init();
        if(Value == 0)
        {
            Value = DEFAULT_EXP_VALUE;
        }
    }

    public override void OnEffect()
    {
        _player.Level.AddExp(Value);
    }}
