using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    public PlayerBase Owner => GameManager.Instance.Player.GetComponent<PlayerBase>();
    public int Level { get; private set; } = 1;
    public bool IsUnlocked;
 
    public virtual void Init()
    {
        SetLevel(1);
    }
    public abstract void LevelUp();

    public void SetLevel(int level)
    {
        Level = level;
    }
}
