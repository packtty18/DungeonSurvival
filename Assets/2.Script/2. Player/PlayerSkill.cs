using UnityEngine;
using System.Collections.Generic;

public class PlayerSkill : MonoBehaviour
{
    private PlayerBase _base;

    public List<ActiveBase> ActivaSkills = new List<ActiveBase>();
    public List<PassiveBase> PassiveSkills = new List<PassiveBase>();

    private List<ActiveBase> ActivateActiveSkills = new List<ActiveBase>();
    private List<PassiveBase> ActivatePassiveSkills = new List<PassiveBase>();

    public Transform DefaultTransform;
    public float autoSkillRange = 10f;

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
        foreach (var skill in ActivateActiveSkills)
        {
            if (!skill.IsReady)
                continue;

            Transform target = FindClosestEnemy(skill);
            if (target != null)
            {
                skill.Activate(target.position);
            }
            else
            {
                skill.Activate(DefaultTransform.position);
            }
        }
    }

    private Transform FindClosestEnemy(ActiveBase skill)
    {
        EnemyBase[] enemies = GameObject.FindObjectsOfType<EnemyBase>();
        Transform closest = null;
        float minDist = autoSkillRange;

        foreach (var enemy in enemies)
        {
            if (!enemy.IsReady) 
                continue;

            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy.transform;
            }
        }

        return closest;
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

    public void AddPassiveSkill(EPassiveSkillType type)
    {
        foreach (PassiveBase skill in PassiveSkills)
        {
            if (skill.Data.skillType != type)
                continue;

            if (!skill.IsUnlocked)
            {
                skill.IsUnlocked = true;
                skill.Init();
                ActivatePassiveSkills.Add(skill);
            }
            else
            {
                skill.LevelUp();
            }

            break;
        }
    }


    public void LevelUpSkill(int index)
    {
        if (index < 0 || index >= ActivateActiveSkills.Count) 
            return;

        ActivateActiveSkills[index].LevelUp();
    }
}
