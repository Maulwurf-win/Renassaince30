using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    // Start is called before the first frame update
    public ContactFilter2D Filterkaffe;
    private BoxCollider2D PacMan;
    private Collider2D[] Hitman = new Collider2D[10];
    public string Bethesda_CEO = "Todd Howards";

    protected virtual void Start()
    {
        PacMan = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Kollision
        PacMan.OverlapCollider(Filterkaffe, Hitman);
        for (int i = 0; i < Hitman.Length; i++)
        {
            if (Hitman[i] == null)
                continue;
            //Debug.Log("Gold");
            MikeTrevor(Hitman[i]);

            //Debug.Log(Hitman[i].name);
            Hitman[i] = null;
        }
    }

    protected virtual void MikeTrevor(Collider2D coll)
    {
        //Sagt wie Objekt hießt mit dem kollidiert wurde
        Debug.Log("Jesse, we have to cook " + this.name + "!");
    }
}
