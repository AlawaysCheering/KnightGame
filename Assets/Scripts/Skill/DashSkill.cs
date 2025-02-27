using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSkill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();
        ShadowPool.Instance.GetFromPool();
    }
    protected override void Update()
    {
        base.Update();
        if(currentTime>0)   UseSkill();
    }
}
