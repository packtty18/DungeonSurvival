using UnityEngine;
using System.Collections.Generic;

public class PlayerSkill : MonoBehaviour
{
    public List<ActiveBase> ActiveSkills = new();
    public List<PassiveBase> PassiveSkills = new();

    private void Update()
    {
        float timer = Time.deltaTime;

        foreach (var skill in ActiveSkills)
            skill.TickCooldown(timer);
    }

    public void ActivateSkill(int index, Vector3 target)
    {
        if (index < 0 || index >= ActiveSkills.Count)
        {
            return;
        }

        ActiveSkills[index].Activate(target);
    }

    public void LevelUpSkill(int index)
    {
        if (index < 0 || index >= ActiveSkills.Count)
        {
            return;
        }
        ActiveSkills[index].LevelUp();
    }
}
