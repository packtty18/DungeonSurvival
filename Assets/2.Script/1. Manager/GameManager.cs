using UnityEngine;

public class GameManager : SimpleSingleton<GameManager>
{
    public GameObject PlayerPrefab;
    public GameObject Player;


    protected override void Awake()
    {
        base.Awake();

        if(Player == null )
        {
            GameObject player = Instantiate(PlayerPrefab);
            Player = player;
            player.transform.position = Vector3.zero;
            Player.transform.rotation = Quaternion.identity;
        }
    }
}
