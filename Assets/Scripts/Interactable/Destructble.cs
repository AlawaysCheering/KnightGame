using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructble : MonoBehaviour
{
    public GameObject destroyVFX;
    [SerializeField] private GameObject reward;
    private void Awake()
    {
        float random = Random.Range(0, 1f);
        if (random <= 0.4f)
        {
            if (random <= 0.3f) reward = Resources.Load<GameObject>("Prefab/RewardHP");
            else reward = Resources.Load<GameObject>("Prefab/RewardAtk");
        }
    }
    public void DestroyObject()
    {
        if(destroyVFX!= null)
        {
            Instantiate(destroyVFX,transform.position, transform.rotation);
        }
        if(reward!= null)
        {
            Instantiate(reward,transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
