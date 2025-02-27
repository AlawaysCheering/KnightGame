using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private  static GameManager instance;
    public static GameManager Instance=>instance;
    public bool isWin = false;
    bool GameOver = false;
    Transform playerPoint;
    public Player player;
    private void Awake()
    {
        instance = this;
        SetPlayerPos();
        DontDestroyOnLoad(gameObject);
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
            Destroy(gameObject);
        }
    }
    public void SetPlayerPos()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerPoint = GameObject.Find("PlayerPoint").transform;
        player.transform.position = playerPoint.position;
        player.transform.rotation = playerPoint.rotation;
    }
    private void Update()
    {
        if (!GameOver)
        {
            CheckGameOver();
        }

    }
    void CheckGameOver()
    {
        if (player.currentHp <= 0)
        {
            UIMgr.Instance.ShowPanel<GameOverPanel>().SetText("”Œœ∑ ß∞‹");
            GameOver = true;
            return;
        }
        if(isWin)
        {
            isWin = false;
            UIMgr.Instance.ShowPanel<GameOverPanel>().SetText("”Œœ∑ §¿˚");
            GameOver = true;
            return;
        }
    }
}
