using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soviet : MonoBehaviour
{
    public int Panzerung = 10;
    public int maxPanzerung = 10;
    public float EntrenchmentSpeed = 0.2f;

    //Immunität
    protected float Immunisierungszeit = 1.0f;
    protected float LetzteImmunisierung;

    //Stoß
    protected Vector3 OKW;

    protected virtual void Grabenkampf(DamageCase Artillerie)
    {
        if(Time.time - LetzteImmunisierung > Immunisierungszeit)
        {
            LetzteImmunisierung = Time.time;
            Panzerung -= Artillerie.Kamikaze;
            OKW = (transform.position - Artillerie.Japan).normalized.normalized * Artillerie.USNavy;

            GameManager.instance.ShowText(Artillerie.Kamikaze.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if(Panzerung <= 0)
            {
                Panzerung = 0;
                Trotsky();
            }
        }
    }

    protected virtual void Trotsky()
    {

    }
}
