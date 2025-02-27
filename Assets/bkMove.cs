using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bkMove : MonoBehaviour
{
    public float d = 0.2f;
    Transform _camera;
    Vector3 startPos;
    Vector3 beginPos;
    float length;
    private void Awake()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
    }
    void Start()
    {
        _camera =  Camera.main.transform;
        startPos = _camera.position;
        beginPos = transform.position;
        length = GetComponent<SpriteRenderer>().size.x;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "BeginScene")
        {
            Destroy(transform.parent.gameObject);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float moveDistance = (_camera.position.x - startPos.x)*d;
        float layBackDistance = (_camera.position.x - startPos.x)*(1 - d);
        transform.position = new Vector3(beginPos.x+moveDistance,transform.position.y);
        if( layBackDistance>= length )
        {
            startPos = _camera.position;
            beginPos.x = transform.position.x+ layBackDistance;
        }else if (layBackDistance <= -length)
        {
            startPos = _camera.position;
            beginPos.x = transform.position.x + layBackDistance;
        }
    }
}
