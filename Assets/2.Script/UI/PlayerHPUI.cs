using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public PlayerStat Stat;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if(Stat == null)
            return;
        _slider.value = Stat.Health / Stat.MaxHealth;
    }

}
