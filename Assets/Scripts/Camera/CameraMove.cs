using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 offset;
    public float moveSpeed = 1;
    Transform Player;
    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
    }
    public float time = 0;
    public Vector3 target;
    public Vector3 beginPos;
    void Start()
    {
        time = 0;
        beginPos = transform.position;
        target = Player.position+offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position + offset != target)
        {
            time = 0;
            beginPos = transform.position;
            target = Player.position+offset;
        }
        time+= Time.deltaTime*moveSpeed;
        transform.position = Vector3.Lerp(beginPos, target, time);
    }
}
