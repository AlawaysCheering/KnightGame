using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour 
{
    public abstract void init();
    private void Start()
    {
        init();
        
    }
}
