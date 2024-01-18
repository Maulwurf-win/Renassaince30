using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDL : Diebesgilde
{
    public Sprite DDR;
    public int GuldenMenge = 5;
    public bool Radio = false;
    protected override void Strauss()
    {
        if(!Finish)
        {
            Finish = true;
            //print("Wurstfinger");
            GetComponent<SpriteRenderer>().sprite = DDR;
            Debug.Log("Eyyy Vitoo, here's " + GuldenMenge + " dollar for ya!");
        }
    }
}