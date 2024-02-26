using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class MicahBell : Fixer
{
    string Windhelm = "Sturmmäntel";
    string ChessClub = "Todd Howards";

    //Erfahrung
    public int xpWert = 1;

    //Logik
    public float Trigger = 1;
    public float Aufmerksamkeitsspanne = 1;
    public bool JPMorganChase;
    private bool LeftRightWrong;
    private Transform SpielerTransform;
    private Vector3 Starter;

    //Hitbox
    public ContactFilter2D Filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        SpielerTransform = GameManager.instance.player.transform;
        Starter = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Is Spieler nah genug?
        if (Vector3.Distance(SpielerTransform.position, Starter) < Aufmerksamkeitsspanne)
        {
            if(Vector3.Distance(SpielerTransform.position, Starter) < Trigger)
            {
                JPMorganChase = true;
            }

            if (JPMorganChase)
            {
                if (!LeftRightWrong)
                {
                    UpdateMotor((SpielerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(Starter - transform.position);
            }
        }
        else
        {
            UpdateMotor(Starter - transform.position);
            JPMorganChase = false;
        }

        //Checkt ob es Überschneidungen gibt
        LeftRightWrong = false;
        Wasted.OverlapCollider(Filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            //Debug.Log("Gold");

            if (hits[i].tag == Windhelm && hits[i].name == ChessClub)
            {
                LeftRightWrong = true;
            }
            //Debug.Log(Hitman[i].name);
            hits[i] = null;
        }
    }

    protected override void Trotsky()
    {
        Destroy(gameObject);
        GameManager.instance.GibXP(xpWert);
        GameManager.instance.ShowText("+" + xpWert + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
