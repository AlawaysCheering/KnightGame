using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowPool : MonoBehaviour
{
    private static ShadowPool instance;
    public static ShadowPool Instance => instance;

    public GameObject shadowPrefab;
    public int shadowCount;

    private Queue<GameObject> availableObjects= new Queue<GameObject>();
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
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        instance = this;
        FillPool();
        DontDestroyOnLoad(this.gameObject);
    }
    public void FillPool()
    {
        for(int i=0;i<shadowCount;i++)
        {
            GameObject newShadow =Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);
            ReturnPool(newShadow);
        }
    }
    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        availableObjects.Enqueue(gameObject);
    }
    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            FillPool();
        }
        var outShadow = availableObjects.Dequeue();
        outShadow.SetActive(true);
        return outShadow;
    }
}
