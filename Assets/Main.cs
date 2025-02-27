using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    Reward reward;
    void Start()
    {
        UIMgr.Instance.ShowPanel<BeginPanel>();      
        reward = gameObject.AddComponent<Reward>();
    }
}
