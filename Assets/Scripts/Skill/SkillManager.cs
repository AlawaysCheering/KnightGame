using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance;
    public static SkillManager Instance => instance;
    public DashSkill dash;

    private void Awake()
    {
        if(instance!=null)
            Destroy(instance);
        else
            instance = this;
        dash = GetComponent<DashSkill>();
    }
}
