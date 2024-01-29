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
            GameManager.instance.ShowText("Eyyy Vitoo, here's " + GuldenMenge + " dollar for ya!", 25, Color.yellow, transform.position, Vector3.up * 25, 2.0f);
            Debug.Log("Eyyy Vitoo, here's " + GuldenMenge + " dollar for ya!");
        }
    }
}
