using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static GameData instance=new GameData();
    public static GameData Instance=>instance;
    public MusicData MusicData;
    private GameData()
    {
        MusicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
    }
    public void SaveMusicData()
    {
        JsonMgr.Instance.SaveData(MusicData,"MusicData");
    }
}
