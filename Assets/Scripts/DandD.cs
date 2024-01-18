using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DandD : CarCrash
{
    public string[] NordGräber;
    protected override void MikeTrevor(Collider2D coll)
    {
        if (coll.name == Bethesda_CEO)
        {
            GameManager.instance.SaveState();
            print("Kartfoffelsack");
            //TP't Spieler in random Dungeon
            string Helgen = NordGräber[Random.Range(0, NordGräber.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(Helgen);
        }
    }
}

