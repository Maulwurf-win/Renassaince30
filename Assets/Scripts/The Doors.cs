using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TheDoors : CarCrash
{
    public string Inside;
    protected override void MikeTrevor(Collider2D coll)
    {
        if(coll.name == Bethesda_CEO)
        {
            GameManager.instance.SaveState();
            SceneManager.LoadScene(Inside);
        }
    }
}
