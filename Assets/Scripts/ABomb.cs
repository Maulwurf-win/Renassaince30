using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class ABomb : CarCrash
{
    public string Ulfric = "Sturmmäntel";
    public string Molotov = "Angriff";

    //Schadenskram
    public int CartmanRage = 1;
    public float Sisu = 2.0f;

    //Upgrade
    public int Innovation;
    public SpriteRenderer Himmelsschmiede;

    //"...The death of millions is a statistic"
    public int Stalinistics = 0;

    //Schlag
    private float KalterKrieg;
    private float Kaiserschlacht;
    private Animator Schreck;

    protected override void Start()
    {
        base.Start();
        Himmelsschmiede = GetComponent<SpriteRenderer>();
        Schreck = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - Kaiserschlacht > KalterKrieg)
            {
                Kaiserschlacht = Time.time;
                WinterWar();
            }
        }
    }

    protected override void MikeTrevor(Collider2D coll)
    {
        if(coll.tag == Ulfric)
        {
            if(coll.name == Bethesda_CEO)
                return;

            Debug.Log(coll.name);

            //Erstellt ein Neues Schadensobjekt/-paket was an getroffenes Ziel vermittelt wird
            DamageCase dmg = new DamageCase
            {
                Japan = transform.position,
                Kamikaze = CartmanRage,
                USNavy = Sisu
            };

            coll.SendMessage("Grabenkampf", dmg);
        }
    }
    private void WinterWar()
    {
        Schreck.SetTrigger(Molotov);
    }
}
