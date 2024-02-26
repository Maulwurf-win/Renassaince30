using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkyrimCourier : CarCrash
{
    public string msg;

    private float cooldown = 4.0f;
    private float letzterDrachenschrei;
    protected override void Start()
    {
        base.Start();
        letzterDrachenschrei = -cooldown;
    }
    protected override void MikeTrevor(Collider2D coll)
    {
        if(Time.time - letzterDrachenschrei > cooldown)
        {
            letzterDrachenschrei = Time.time;
            GameManager.instance.ShowText(msg, 25, Color.white, transform.position + new Vector3(0,0.16f,0), Vector3.zero, cooldown);
        }
    }
}
