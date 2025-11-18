using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SimpleSingleton<UIManager>
{
    [SerializeField] private Text _scoreTextUI;

    [SerializeField] private Vector3 _tweeningSize;
    [SerializeField] private float _tweenDuration;

    [Header("Input")]
    [SerializeField] private Button _healButton;
    [SerializeField] private Text _healCostTextUI;
    [SerializeField] private Button _shotGunButton;
    [SerializeField] private Text _shotgunCostTextUI;
    [SerializeField] private Button _rapidFireUpgrade;
    [SerializeField] private Text _rapidFireCostTextUI;

    private Dictionary<EuttonType, Button> _buttonDictionary = new Dictionary<EuttonType, Button>();

    private int healCount = 0;

    protected override void Awake()
    {
        base.Awake();
        MatchButtonEnum();
    }

    private void MatchButtonEnum()
    {
        _buttonDictionary.Add(EuttonType.Heal, _healButton);
        _buttonDictionary.Add(EuttonType.ShotgunUpgrade, _shotGunButton);
        _buttonDictionary.Add(EuttonType.RapidFireUpgrade, _rapidFireUpgrade);
    }

    private void ChangeText(Text target, string text)
    {
        target.text = text;
    }

    public void ChangeScoreText(string text, bool tween = true)
    {
        ChangeText(_scoreTextUI, text);

        if (!tween)
        {
            return;
        }

        //자체제작 클래스를 사용한 방법
        Tweening tweening = _scoreTextUI.GetComponent<Tweening>();
        tweening.StartTweening();
    }
    public Button GetButton(EuttonType buttonType)
    {
        return _buttonDictionary[buttonType];
    }

    public void ChangeShotgunCostText(string text)
    {
        ChangeText(_shotgunCostTextUI, text);
    }

    public void ChangeRapidFireCostText(string text)
    {
        ChangeText(_rapidFireCostTextUI, text);
    }

    public void ChangeHealCostText(string text)
    {
        ChangeText(_healCostTextUI, text);
    }

    // 샷건 업그레이드 버튼 클릭
    public void UpgradeShotgunHandler()
    {

        PlayerBase playerBase = GameManager.Instance.Player.GetComponent<PlayerBase>();
        PlayerSkill skill = playerBase.GetComponent<PlayerSkill>();
        if (!playerBase.IsReady)
            return;

        ActiveBase active = skill.GetSkill(EActiveSkillType.Shotgun);


        if (active.Level == active.Data.maxLevel)
        {
            return;
        }

        if (playerBase.Stat.Level < active.Level)
        {
            return; 
        }

        if (!ScoreManager.IsManagerExist())
        {
            return;
        }

        int cost = 500 + (active.Level - 1) * 200;
        if (!ScoreManager.Instance.IsScoreCanReduce(cost))
        {
            return;
        }

        
        ScoreManager.Instance.ReduceScore(cost);

        if (skill != null)
        {
            skill.AddActiveSkill(EActiveSkillType.Shotgun);
        }
        
        int newCost = 500 + (active.Level - 1) * 200;
        ChangeShotgunCostText(newCost.ToString());
    }

    // 속사 업그레이드 버튼 클릭
    public void UpgradeRapidFireHandler()
    {
        PlayerBase playerBase = GameManager.Instance.Player.GetComponent<PlayerBase>();
        PlayerSkill skill = playerBase.GetComponent<PlayerSkill>();
        if (!playerBase.IsReady)
            return;

        ActiveBase active = skill.GetSkill(EActiveSkillType.RapidFire);


        if (active.Level == active.Data.maxLevel)
        {
            return;
        }

        if (playerBase.Stat.Level < active.Level)
        {
            return;
        }

        if (!ScoreManager.IsManagerExist())
        {
            return;
        }

        int cost = 500 + (active.Level - 1) * 200;
        if (!ScoreManager.Instance.IsScoreCanReduce(cost))
        {
            return;
        }
        ScoreManager.Instance.ReduceScore(cost);

        if (skill != null)
        {
            skill.AddActiveSkill(EActiveSkillType.RapidFire);
        }

        int newCost = 500 + (active.Level - 1) * 200;
        ChangeRapidFireCostText(newCost.ToString());
    }

    // 힐 버튼 클릭
    public void HealHandler()
    {
        int cost = healCount * 100 + 1000;

        PlayerBase playerBase = GameManager.Instance.Player.GetComponent<PlayerBase>();
        if (!playerBase.IsReady)
            return;
        if (!ScoreManager.IsManagerExist())
        {
            return;
        }
        if (!ScoreManager.Instance.IsScoreCanReduce(cost))
        {
            return;
        }
        ScoreManager.Instance.ReduceScore(cost);
        // 플레이어 체력 회복
        PlayerHealth health = playerBase.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.OnHeal(health.MaxHealth * 0.5f); // 예: 현재 체력의 50% 회복
            healCount++;
        }
        int newCost = healCount * 100 + 1000;
        ChangeHealCostText(newCost.ToString());
    }
}
