using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DandD : CarCrash
{
    public string[] NordGr�ber;
    protected override void MikeTrevor(Collider2D coll)
    {
        if (coll.name == Bethesda_CEO)
        {
            GameManager.instance.SaveState();
            print("Kartfoffelsack");
            //TP't Spieler in random Dungeon
            string Helgen = NordGr�ber[Random.Range(0, NordGr�ber.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(Helgen);
        }
    }
}

