using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public PlayerStat Stat;
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
