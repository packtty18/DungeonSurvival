using UnityEngine;
using UnityEngine.UI;

public class PlayerImage : MonoBehaviour
{
    public SpriteRenderer playerRenderer => GameManager.Instance.Player.GetComponent<SpriteRenderer>();
    private Image _imageUI;

    private void Start()
    {
        
        _imageUI = GetComponent<Image>();
    }
    private void Update()
    {
        if (playerRenderer == null)
            return;

        _imageUI.sprite = playerRenderer.sprite;
    }

}
