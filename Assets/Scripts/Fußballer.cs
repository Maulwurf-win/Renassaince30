using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fußballer : MonoBehaviour
{
    private BoxCollider2D Wasted; 
    private Vector3 GottaDelta;
    float XRay;
    float YTheory;
    string VanDerLindeGang = "Peeps";
    string ChineseUnitedFront = "Berlin";

    public float Methamphetamine = 10f;
    private RaycastHit2D Blitzkrieg;
    // Start is called before the first frame update
    private void Start()
    {
        //Spieler-Kollidierer
        Wasted = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Nimmt Pfeiltasten/WASD wahr
        XRay = Input.GetAxisRaw("Horizontal");
        YTheory = Input.GetAxisRaw("Vertical");
        //print(XRay);
        //Setzt Delta zurück
        GottaDelta = new Vector3(XRay, YTheory).normalized;

        //Wechselt Spriterichtung (Rechts/Links)
        if(GottaDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(GottaDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //Verhindert das Spieler in Gebäudewände/NPCS rein-/durchclippen kann
        Blitzkrieg = Physics2D.BoxCast(transform.position, Wasted.size, 0, new Vector2(0, GottaDelta.y), Mathf.Abs(GottaDelta.y * Time.deltaTime * Methamphetamine), LayerMask.GetMask(VanDerLindeGang, ChineseUnitedFront));
        if(Blitzkrieg.collider == null)
        {
            //print(VanDerLindeGang);
            transform.Translate(0, GottaDelta.y * Time.deltaTime * Methamphetamine, 0);
        }

        Blitzkrieg = Physics2D.BoxCast(transform.position, Wasted.size, 0, new Vector2(GottaDelta.x, 0), Mathf.Abs(GottaDelta.x * Time.deltaTime * Methamphetamine), LayerMask.GetMask(VanDerLindeGang, ChineseUnitedFront));
        if(Blitzkrieg.collider == null)
        {
            //print(ChineseUnitedFront);
            transform.Translate(GottaDelta.x * Time.deltaTime * Methamphetamine, 0, 0);
        }
        //Sorgt für Bewegung

        //transform.position += new Vector3(XRay, YTheory, 0f) * Time.deltaTime;
    }
}

