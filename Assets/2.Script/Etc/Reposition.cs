using System.Runtime.CompilerServices;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector2 playerPos = GameManager.Instance.Player.transform.position;
        Vector2 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector2 playerDir = GameManager.Instance.Player.GetComponent<PlayerInput>().MoveDirection;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                {
                    if(diffX > diffY)
                    {
                        transform.Translate(Vector2.right * dirX * 40);
                    }
                    else if(diffX <diffY)
                    {
                        transform.Translate(Vector2.up * dirY * 40);
                    }
                   break;
                }
            default:
                {
                    if (!_collider.enabled) 
                        break;
                    Vector2 save = transform.position;

                    float offset = 10;
                    float moveDistance = 20;

                    Vector2 newPos = myPos;

                    if (diffX > diffY)
                    {
                        float offsetY = Random.Range(-offset, offset);
                        newPos.x = myPos.x + dirX * moveDistance;
                        newPos.y = playerPos.y + offsetY;
                    }
                    else
                    {
                        float offsetX = Random.Range(-offset, offset);
                        newPos.y = myPos.y + dirY * moveDistance;
                        newPos.x = playerPos.x + offsetX;
                    }

                    transform.position = newPos;

                    Debug.Log($"repositioned:{save} -> {transform.position}");
                    break;
                }
        }



    }
}
