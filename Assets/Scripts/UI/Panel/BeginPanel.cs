using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    public Button btnStart;
    public Button btnSetting;
    public Button btnQuit;
    public override void init()
    {
        btnStart.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<BeginPanel>();
            SceneManager.LoadScene("GamePlay");
        });
        btnSetting.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<SettingPanel>();
        });
        btnQuit.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<BeginPanel>();
            Application.Quit();
        });
    }
}
