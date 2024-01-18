using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsiatedesVertrauens : Diebesgilde
{
    public Sprite DDR;
    public bool Wurst;
    public int GuldenMenge = 5;

    protected override void Strauss()
    {
        if (!Finish)
        {
            Finish = true;
            print(Finish);
            GetComponent<SpriteRenderer>().sprite = DDR;
            Debug.Log("Eyyy Vitoo, here's " + GuldenMenge + " dollar for ya!");
        }
    }
}
