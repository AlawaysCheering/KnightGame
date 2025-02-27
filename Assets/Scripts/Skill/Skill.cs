using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public float cooldown;
    public float skillTimer;
    public float skillDuration;
    public float currentTime;
    public Image skillCoolDown;

    protected virtual void Update()
    {
        if (skillTimer > 0)
        {
            skillCoolDown.fillAmount -= 1.0f / cooldown * Time.deltaTime;
        }
        skillTimer -=Time.deltaTime;
        currentTime-=Time.deltaTime;
    }
    public virtual bool CanUseSkill()
    {
        if (skillTimer < 0)
        {
            UseSkill();
            skillTimer = cooldown;
            currentTime = skillDuration;
            skillCoolDown.fillAmount = 1;
            return true;
        }

        return false;
    }
    public virtual void UseSkill()
    {
    }
}
