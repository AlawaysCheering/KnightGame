using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : BasePanel
{
    public TextMeshProUGUI text;
    public Button btn;
    public override void init()
    {
        btn.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<GameOverPanel>();
            SceneManager.LoadScene("BeginScene");
        });
    }

    public void SetText(string str)
    {
        text.text = str;
    }
}
