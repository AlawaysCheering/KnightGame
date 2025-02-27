using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr
{
    private Dictionary<string, BasePanel> panelDic;
    private static UIMgr instance=new UIMgr();
    public static UIMgr Instance=>instance;
    private Transform canvas;
    private UIMgr() { 
        panelDic = new Dictionary<string, BasePanel>();
        canvas = GameObject.Instantiate(Resources.Load<GameObject>("UI/Canvas")).transform;
        GameObject.DontDestroyOnLoad(canvas);
    }
    public T ShowPanel<T>() where T : BasePanel
    {
        string name = "UI/"+typeof(T).Name;
        if (!panelDic.ContainsKey(name))
        {
            T panel = GameObject.Instantiate(Resources.Load<GameObject>(name), canvas).GetComponent<T>();
            panelDic.Add(name, panel);
            return panel;

        }else return panelDic[name] as T;
    }
    public void HidePanel<T>() where T : BasePanel
    {
        string name = "UI/" + typeof(T).Name;
        if (panelDic.ContainsKey(name))
        {
            GameObject.DestroyImmediate(panelDic[name].gameObject);
            panelDic.Remove(name);
        }
    }
    public T GetPanel<T>() where T : BasePanel
    {
        string name = "UI/" + typeof(T).Name;
        if (panelDic.ContainsKey(name))
        {
            return (T)panelDic[name];
        }
        else
        {
            return null;
        }
    }
}
