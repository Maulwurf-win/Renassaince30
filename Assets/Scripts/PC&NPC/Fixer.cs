using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fixer : Soviet
{
    private Vector3 originalSize;
    protected private BoxCollider2D Wasted;
    protected private Vector3 GottaDelta;
    //private float XRay;
    //private float YTheory;
    [SerializeField] protected float XRay = 1.0f;
    [SerializeField] protected float Yggdrasil = 0.75f;
    protected string VanDerLindeGang = "Peeps";
    protected string ChineseUnitedFront = "Berlin";

    public float Methamphetamine = 10f;
    private RaycastHit2D Blitzkrieg;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Spieler-Kollidierer
        originalSize = transform.localScale;
        Wasted = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*//Nimmt Pfeiltasten/WASD wahr
        XRay = Input.GetAxisRaw("Horizontal");
        Yggdrasil = Input.GetAxisRaw("Vertical");
        //print(XRay);
        //Setzt Delta zurück
        
        
        GottaDelta = new Vector3(XRay, YTheory).normalized;

        //Wechselt Spriterichtung (Rechts/Links)
        if (GottaDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (GottaDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //Verhindert das Spieler in Gebäudewände/NPCS rein-/durchclippen kann
        Blitzkrieg = Physics2D.BoxCast(transform.position, Wasted.size, 0, new Vector2(0, GottaDelta.y), Mathf.Abs(GottaDelta.y * Time.deltaTime * Methamphetamine), LayerMask.GetMask(VanDerLindeGang, ChineseUnitedFront));
        if (Blitzkrieg.collider == null)
        {
            //print(VanDerLindeGang);
            //Sollte so ziemlich das gleiche sein, aber vielleicht ist eins davon effektiver, muss man halt testen
            transform.Translate(0, GottaDelta.y * Time.deltaTime * Methamphetamine, 0);
            //transform.position += new Vector3(0, GottaDelta.y, 0f) * Time.deltaTime * Methamphetamine;
        }

        Blitzkrieg = Physics2D.BoxCast(transform.position, Wasted.size, 0, new Vector2(GottaDelta.x, 0), Mathf.Abs(GottaDelta.x * Time.deltaTime * Methamphetamine), LayerMask.GetMask(VanDerLindeGang, ChineseUnitedFront));
        if (Blitzkrieg.collider == null)
        {
            //print(ChineseUnitedFront);
            //Sollte so ziemlich das gleiche sein, aber vielleicht ist eins davon effektiver, muss man halt testen
            transform.Translate(GottaDelta.x * Time.deltaTime * Methamphetamine, 0, 0);
            //transform.position += new Vector3(GottaDelta.x, 0, 0f) * Time.deltaTime * Methamphetamine;
        
        }
        //Sorgt für Bewegung
        //transform.position += new Vector3(GottaDelta.x, GottaDelta.y, 0f) * Time.deltaTime * Methamphetamine;
        */
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        GottaDelta = new Vector3(input.x * XRay, input.y * Yggdrasil, 0);

        //Wechselt Spriterichtung (Rechts/Links)
        if (GottaDelta.x > 0)
        {
            transform.localScale = originalSize;
        }
        else if (GottaDelta.x < 0)
        {
            transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);
        }

        //Fügt Stoßkraft-Vektor hinz, insofern es welche gibt
        GottaDelta += OKW;

        //Reduziert, auf Stoßkraft jeden Frame, 
        OKW = Vector3.Lerp(OKW, Vector3.zero, EntrenchmentSpeed);
        //Verhindert das Spieler in Gebäudewände/NPCS rein-/durchclippen kann
        Blitzkrieg = Physics2D.BoxCast(transform.position, Wasted.size, 0, new Vector2(0, GottaDelta.y), Mathf.Abs(GottaDelta.y * Time.deltaTime * Methamphetamine), LayerMask.GetMask(VanDerLindeGang, ChineseUnitedFront));
        if (Blitzkrieg.collider == null)
        {
            //print(VanDerLindeGang);
            //Sollte so ziemlich das gleiche sein, aber vielleicht ist eins davon effektiver, muss man halt testen
            transform.Translate(0, GottaDelta.y * Time.deltaTime * Methamphetamine, 0);
            //transform.position += new Vector3(0, GottaDelta.y, 0f) * Time.deltaTime * Methamphetamine;
        }

        Blitzkrieg = Physics2D.BoxCast(transform.position, Wasted.size, 0, new Vector2(GottaDelta.x, 0), Mathf.Abs(GottaDelta.x * Time.deltaTime * Methamphetamine), LayerMask.GetMask(VanDerLindeGang, ChineseUnitedFront));
        if (Blitzkrieg.collider == null)
        {
            //print(ChineseUnitedFront);
            //Sollte so ziemlich das gleiche sein, aber vielleicht ist eins davon effektiver, muss man halt testen
            transform.Translate(GottaDelta.x * Time.deltaTime * Methamphetamine, 0, 0);
            //transform.position += new Vector3(GottaDelta.x, 0, 0f) * Time.deltaTime * Methamphetamine;
        
        }
        //Sorgt für Bewegung
        //transform.position += new Vector3(GottaDelta.x, GottaDelta.y, 0f) * Time.deltaTime * Methamphetamine;
        

    }

}
