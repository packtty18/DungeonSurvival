using UnityEngine;
using UnityEngine.UI;

public class PlayerExpUI : MonoBehaviour
{
    public PlayerStat Stat => GameManager.Instance.Player.GetComponent<PlayerStat>();
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (Stat == null)
            return;
        _slider.value = Stat.CurrentExp / Stat.NextExp;
    }
}
