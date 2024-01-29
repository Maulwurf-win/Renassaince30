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
            GameManager.instance.ShowText("+" + GuldenMenge + " Gulden", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            Debug.Log("Eyyy Vitoo, here's " + GuldenMenge + " dollar for ya!");
        }
    }
}