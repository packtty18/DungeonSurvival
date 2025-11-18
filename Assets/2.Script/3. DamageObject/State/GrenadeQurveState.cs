using UnityEngine;

public class GrenadeCurveState : IDamageObjectState
{
    private Grenade _grenade;

    public void Enter(BaseDamageObject owner)
    {
        _grenade = owner as Grenade;
    }

    public void Tick(float deltaTime)
    {
        if (_grenade == null) return;

        _grenade.Elapse += deltaTime;
        float t = Mathf.Clamp01(_grenade.Elapse / _grenade.Duration);

        // 포물선 계산
        Vector3 pos = Vector3.Lerp(_grenade.StartPos, _grenade.TargetPos, t);
        pos.y += Mathf.Sin(t * Mathf.PI) * _grenade.Height;
        _grenade.transform.position = pos;

        if (t >= 1f)
            _grenade.Explode();
    }

    public void Exit()
    {
        _grenade = null;
    }
}
