using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFx : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private float flashDuration;
    private Material originMaterial;
    [SerializeField] private Material flashMaterial;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originMaterial = sr.material;
    }

    IEnumerator flashFx()
    {
        sr.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        sr.material = originMaterial;
    }
    public void onHurt()
    {
        if (sr.color == Color.white) sr.color = Color.red;
        else sr.color = Color.white;
    }
    public void OnHurtStart()
    {
        InvokeRepeating("onHurt", 0,.1f);
    }
    public void OnHurtEnd()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
    public void SetColorClear()
    {
        sr.color=Color.clear;
    }
    public void SetColorWhite()
    {
        sr.color=Color.white;
    }
}
