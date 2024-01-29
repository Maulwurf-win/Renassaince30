using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shitbox : CarCrash
{
    //Schden
    public int Kollateralschaden = 1;
    public float PanzerPush = 5;
    string Windhelm = "Sturmmäntel";
    string ChessClub = "Todd Howards";

    protected override void MikeTrevor(Collider2D coll)
    {
        if(coll.tag == Windhelm && coll.name == ChessClub)
        {
            //Erstellt ein Neues Schadensobjekt/-paket was an getroffenes Ziel vermittelt wird
            DamageCase dmg = new DamageCase
            {
                Japan = transform.position,
                Kamikaze = Kollateralschaden,
                USNavy = PanzerPush,
            };

            coll.SendMessage("Grabenkampf", dmg);
        }
    }
}
