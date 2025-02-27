using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private static PlayerManager instance= new PlayerManager();
    public static PlayerManager Instance =>instance;
    public Player player;
    private PlayerManager()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
}
