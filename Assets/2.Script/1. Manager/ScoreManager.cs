
using UnityEngine;

public class ScoreManager : SimpleSingleton<ScoreManager>
{
    [SerializeField]private int _currentScore = 0;
    public int CurrentScore => _currentScore;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _currentScore = 0;
        RefreshScoreUI(false);
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        RefreshScoreUI();
    }

    public bool IsScoreCanReduce(int value)
    {
        return _currentScore - value >= 0;
    }


    public void ReduceScore(int score)
    {
        if(!IsScoreCanReduce(score))
        {
            return;
        }

        _currentScore -= score;  
        RefreshScoreUI();
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }


    /// <summary>
    /// UI 갱신
    /// </summary>
    private void RefreshScoreUI(bool IsActiveTween = true)
    {
        if (!UIManager.IsManagerExist()) return;

        var ui = UIManager.Instance;
        ui.ChangeScoreText($"현재 점수 : {_currentScore:N0}", IsActiveTween);
    }
}
