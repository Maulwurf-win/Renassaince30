using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chell : CarCrash
{
    //public string Wheatley = "Main";
    protected override void MikeTrevor(Collider2D coll)
    {
        if (coll.name == Bethesda_CEO)
        {
            GameManager.instance.SaveState();
            ScenesManager.Instance.LoadMain();
        }
    }
}
