using UnityEngine;
using System.Collections.Generic;

public class PlayerSkill : MonoBehaviour
{
    private PlayerBase _base;

    public List<ActiveBase> ActivaSkills = new List<ActiveBase>();
    private List<ActiveBase> ActivateActiveSkills = new List<ActiveBase>();

    public Transform DefaultTransform;
    public float AutoSkillRange = 10f;

    public void Init(PlayerBase playerBase)
    {
        _base = playerBase;
        Debug();
    }

    private void Update()
    {
        if(_base == null || !_base.IsReady)
        {
            return;
        }

        float deltaTime = Time.deltaTime;

        foreach (var skill in ActivateActiveSkills)
        {
            skill.TickCooldown(deltaTime);
        }

        AutoCastSkills();
    }

    private void AutoCastSkills()
    {
        if (DefaultTransform.position == Vector3.zero)
            return;

        foreach (var skill in ActivateActiveSkills)
        {
            if (!skill.IsReady)
                continue;

            skill.Activate(DefaultTransform.position);
        }
    }
    
    [ContextMenu("ActivateShotgun")]
    public void Debug()
    {
        AddActiveSkill(EActiveSkillType.Shotgun);
        AddActiveSkill(EActiveSkillType.RapidFire);
    }

    public void AddActiveSkill(EActiveSkillType type)
    {
        foreach (ActiveBase skill in ActivaSkills)
        {
            if (skill.Data.skillType != type)
                continue;

            if (!skill.IsUnlocked)
            {
                skill.IsUnlocked = true;
                skill.Init();
                ActivateActiveSkills.Add(skill);
            }
            else
            {
                skill.LevelUp();
            }

            break;
        }
    }
}
