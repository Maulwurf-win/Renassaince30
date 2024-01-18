using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diebesgilde : CarCrash
{
    protected bool Finish;

    protected override void MikeTrevor(Collider2D coll)
    {
        //base.MikeTrevor(coll);
        //Debug.Log("Trevor!!!");
        if(coll.name == Bethesda_CEO)
        {
            //print("Döner");
            Strauss();
        }
    }

    protected virtual void Strauss()
    {
        Finish = true;
        print(Finish);
    }
}
