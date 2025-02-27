using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChuanSongMen : MonoBehaviour
{
    string SceneName="BossPlay";
    Player player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void SetSceneName(string sceneName)
    {
        SceneName = sceneName;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&Vector2.Distance(transform.position, player.transform.position)<1)
        {
            if (SceneName == "Win")
            {
                GameManager.Instance.isWin = true;  
                Audio.Instance.ChangeMusic(0);
            }
            else
            {
                SceneManager.LoadScene(SceneName);
                GameManager.Instance.SetPlayerPos();
                Audio.Instance.ChangeMusic(1);
            }
        }
    }
}
