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
    public int[] CartmanRage = {1, 2, 3, 4, 5};
    public float[] Sisu = {2.0f, 2.2f, 2.5f, 3.0f, 3.7f};

    //Upgrade
    public int Innovation = 0;
    public SpriteRenderer Himmelsschmiede;

    //"...The death of millions is a statistic"
    public int Stalinistics = 0;

    //Schlag
    private float KalterKrieg;
    private float Kaiserschlacht;
    private Animator Schreck;

    private void Awake()
    {
        Himmelsschmiede = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        base.Start();
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
                Kamikaze = CartmanRage[Innovation],
                USNavy = Sisu[Innovation]
            };

            coll.SendMessage("Grabenkampf", dmg);
        }
    }
    private void WinterWar()
    {
        Schreck.SetTrigger(Molotov);
    }

    public void Upgrade()
    {
        Innovation++;
        Himmelsschmiede.sprite = GameManager.instance.WaffenSprites[Innovation];
    }

    public void WaffenLevelFestlegung(int level)
    {
        Innovation = level;
        Himmelsschmiede.sprite = GameManager.instance.WaffenSprites[Innovation];
    }
}
