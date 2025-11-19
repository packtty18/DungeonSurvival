using UnityEngine;

public class Exp : ItemBase
{
    private const float DEFAULT_EXP_VALUE = 2;

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
        SoundManager.Instance.CreateSFX(ESFXType.GetExp, transform.position);
        _player.Level.AddExp(Value);
    }}
