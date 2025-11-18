using UnityEngine;
using UnityEngine.UI;

public class PlayerImage : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
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
