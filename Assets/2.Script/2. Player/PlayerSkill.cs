using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
        AddActiveSkill(EActiveSkillType.Shotgun);
        AddActiveSkill(EActiveSkillType.RapidFire);
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

    public ActiveBase GetSkill(EActiveSkillType type)
    {
        foreach (ActiveBase skill in ActivaSkills)
        {
            if (skill.Data.skillType != type)
                continue;

            return skill;
        }

        return null;
    }

    public void UpgradeShotgun()
    {
        AddActiveSkill(EActiveSkillType.Shotgun);
    }

    public void UpgradeRapidFire()
    {
        AddActiveSkill(EActiveSkillType.RapidFire);
    }
}
