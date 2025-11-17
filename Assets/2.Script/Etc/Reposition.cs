using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
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
            case "Enemy":
                {
                    transform.Translate(playerDir * 10 + new Vector2(Random.Range(-3f, 3), Random.Range(-3f, 3f)));
                    break;
                }
        }



    }
}
