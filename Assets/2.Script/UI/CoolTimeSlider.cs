using UnityEngine;
using UnityEngine.UI;

public class CoolTimeSlider : MonoBehaviour
{
    public ActiveBase Skill;
    private Slider _sliderUI;

    float Cooldown => Skill.Data.levelStats[Skill.Level - 1].Cooldown;

    private void Start()
    {
        _sliderUI = GetComponent<Slider>();
    }
    private void Update()
    {
        if (Skill == null)
            return;
        _sliderUI.value =1f - ( Skill.CoolTimer / Cooldown);
    }
    
}
