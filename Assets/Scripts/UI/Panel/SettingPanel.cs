using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Button btnBack;
    public Slider sliderMusic;
    public Slider sliderSound;
    public override void init()
    {
        InitMusicInfo();
        sliderMusic.onValueChanged.AddListener((val) =>
        {
            GameData.Instance.MusicData.musicVal = val;
            Audio.Instance.SetMusicValue(val);
        });
        sliderSound.onValueChanged.AddListener((val) =>
        {
            GameData.Instance.MusicData.soundVal = val;
            Audio.Instance.SetSoundValue(val);
        });
        btnBack.onClick.AddListener(() =>
        {
            GameData.Instance.SaveMusicData();
            UIMgr.Instance.HidePanel<SettingPanel>();
        });
    }
    public void InitMusicInfo()
    {
        MusicData musicData = GameData.Instance.MusicData;
        SetMusicVal(musicData.musicVal);
        SetSoundVal(musicData.soundVal);
    }
    public void SetMusicVal(float val)
    {
        sliderMusic.value = val;
    }
    public void SetSoundVal(float val)
    {
        sliderSound.value = val;
    }
}
