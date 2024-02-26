using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class American_Healthcare : CarCrash
{
    public int Heilungspunkte = 1;
    private float HeilungsCooldown = 1.0f;
    private float LetzteHeilung;

    protected override void MikeTrevor(Collider2D coll)
    {
        if(coll.name != Bethesda_CEO)
            return;

        if(Time.time - LetzteHeilung > HeilungsCooldown)
        {
            print("I have a plan");
            LetzteHeilung = Time.time;
            GameManager.instance.player.Heilung(Heilungspunkte);
        }
    }
}
