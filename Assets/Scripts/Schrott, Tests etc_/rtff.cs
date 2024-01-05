using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtff : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    /*float x;
    float y;*/
    /*string VanDerLindeGang = "Peeps";
    string ChineseUnitedFront = "Berlin";*/

    public float Methamphetamine = 10f;
    private RaycastHit2D hit;
    private void Start()
    {
        //Spieler-Kollidierer
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Nimmt Pfeiltasten/WASD wahr
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Setzt Delta zurück
        moveDelta = new Vector3(x, y, 0).normalized;

        //Wechselt Spriterichtung (Rechts/Links)
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Verhindert das Spieler in Gebäudewände/NPCS rein-/durchclippen kann
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Peeps", "Berlin"));
        if (hit.collider == null)
        {
            print("Peeps");
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        else
        {
            print("Poggers");
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Peeps", "Berlin"));
        if (hit.collider == null)
        {
            print("Berlin");
            transform.Translate(moveDelta.x * Time.deltaTime , 0, 0);
        }
        else
        {
            print("Merkel");
        }
        //Sorgt für Bewegung

        //transform.position += new Vector3(XRay, YTheory, 0f) * Time.deltaTime;
    }
}
