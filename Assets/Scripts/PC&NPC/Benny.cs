using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Benny : Fixer
{
    private SpriteRenderer ISP;
    public string Starfield = "Todd Howards";
    public string EminemShow = "Show";
    private bool StayAlive = true;


    protected override void Start()
    {
        base.Start();
        ISP = GetComponent<SpriteRenderer>();
        //DontDestroyOnLoad(gameObject);
    }

    protected override void Grabenkampf(DamageCase Artillerie)
    {
        if(!StayAlive)
            return;
        base.Grabenkampf(Artillerie);
        GameManager.instance.BeiHitpointÄnderung();
    }

    protected override void Trotsky()
    {
        StayAlive = false;
        GameManager.instance.ODeath.SetTrigger(EminemShow);
    }
    private void FixedUpdate()
    {
        float XPath = Input.GetAxisRaw("Horizontal");
        float YTheory = Input.GetAxisRaw("Vertical");
        if(StayAlive)
            UpdateMotor(new Vector3(XPath, YTheory, 0).normalized);
    }

    public void Regierungswechsel(int skinID)
    {
        ISP.sprite = GameManager.instance.SpielerSprites[skinID];
    }

    public void BeiLevelAufstieg()
    {
        maxPanzerung++;
        Panzerung = maxPanzerung;
    }

    public void LevelFestlegung(int level)
    {
        for (int i = 0; i < level; i++)
            BeiLevelAufstieg();
    }

    public void Heilung(int HeilungsPunkte)
    {
        if(Panzerung == maxPanzerung)
            return;

        Panzerung += HeilungsPunkte;
        if (Panzerung > maxPanzerung)
            Panzerung = maxPanzerung;
        GameManager.instance.ShowText("+ " + HeilungsPunkte.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.BeiHitpointÄnderung();
    }

    public void Respwan()
    {
        StayAlive = true;
        Heilung(maxPanzerung);
        LetzteImmunisierung = Time.time;
        OKW = Vector3.zero;
        
    }
}
