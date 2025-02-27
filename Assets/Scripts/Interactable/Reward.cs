using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RewardType
{
    AddHP,
    AddAtk
}
public class Reward : MonoBehaviour
{
    public float canUseDistance=1;
    public int addValue;
    [SerializeField] RewardType type;
    Player player;
    private void Awake()
    {
        player= GameObject.Find("Player")?.GetComponent<Player>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&Vector3.Distance(transform.position,player.transform.position)<=canUseDistance)
        {
            if (type == RewardType.AddHP)
            {
                player.SetHp(player.currentHp + addValue);
            }
            else if (type == RewardType.AddAtk)
            {
                player.originalAtk += addValue;
            }
            Destroy(gameObject);
        }
    }
}
