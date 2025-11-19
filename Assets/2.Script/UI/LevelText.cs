using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public PlayerStat Stat => GameManager.Instance.Player.GetComponent<PlayerStat>();
    private Text _textUI;

    private void Start()
    {
        _textUI = GetComponent<Text>();
    }

    private void Update()
    {
        _textUI.text = Stat.Level.ToString();
    }
}
