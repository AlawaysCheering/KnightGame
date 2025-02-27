using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{

    #region 基础参数
    public bool isDead = false;
    public float maxHp;
    public float currentHp;
    public float buffTime = 0.5f;
    #endregion
    #region 血条UI
    public Image hpImg;
    public Image hpEffectImg;
    private Coroutine updateCoroutine;
    #endregion
    #region 组件
    public  Animator anim;
    public Rigidbody2D rb;
    public EntityFx entityFx;
    #endregion
    public int FacingDir = 1;
    public bool FacingRight= true;
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected float GroudCheckDistance;
    [SerializeField] protected Transform WallCheck;
    [SerializeField] protected float WallCheckDistance;
    public Transform AttackCheck;
    public float AttackCheckRadius;
    //protected Transform Attack
    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        entityFx = GetComponentInChildren<EntityFx>();
    }
    protected virtual void Start()
    {
        currentHp = maxHp;
        UpdateHealthBar();
    }
    protected virtual void UpdateHealthBar()
    {
        hpImg.fillAmount = currentHp / maxHp;
        if(updateCoroutine != null)
        {
            StopCoroutine(updateCoroutine);
        }
        updateCoroutine = StartCoroutine(UpdateHpEffect());
    }
    public void SetHp(float hp)
    {
        currentHp=Mathf.Clamp(hp, 0, maxHp);
        UpdateHealthBar();
    }
    protected virtual IEnumerator UpdateHpEffect()
    {
        float effectLength =hpEffectImg.fillAmount-hpImg.fillAmount;
        float elapsedTime=0;
        while(elapsedTime < buffTime&&effectLength!=0)
        {
            elapsedTime += Time.deltaTime;
            hpEffectImg.fillAmount = Mathf.Lerp(hpImg.fillAmount+effectLength,hpImg.fillAmount,elapsedTime/buffTime);
            yield return null;
        }
        hpEffectImg.fillAmount = hpImg.fillAmount;
        if(hpImg.fillAmount==0)
        {
            Dead();
        }
    }


    protected virtual void Update()
    {
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadLine")
        {
            SetHp(0);
        }
    }

    public void Flip()
    {
        FacingDir = FacingDir * -1;
        FacingRight = !FacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
    public void FilpController(float _x)
    {
        if (isDead) return;
        if (_x > 0 && !FacingRight) Flip();
        else if (_x < 0 && FacingRight) Flip();
    }
    public bool isWallTouched() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDir, WallCheckDistance, 1 << LayerMask.NameToLayer("Ground")| 1 << LayerMask.NameToLayer("Destruct"));
    public bool isGround() => Physics2D.Raycast(GroundCheck.position, Vector2.up, -GroudCheckDistance, 1 << LayerMask.NameToLayer("Ground")|1 << LayerMask.NameToLayer("Destruct"));
    public virtual void SetVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
        FilpController(x);
    }

    public virtual void Damage(int hurtValue) {
        if (isDead) return;
        entityFx.StartCoroutine("flashFx");
        SetHp(currentHp-hurtValue);
    }


    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(GroundCheck.position, new Vector3(GroundCheck.position.x, GroundCheck.position.y - GroudCheckDistance));
        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance * FacingDir, WallCheck.position.y));
        Gizmos.DrawWireSphere(AttackCheck.position, AttackCheckRadius);
    }

    protected virtual void Dead() {
        isDead = true;
    }

}
