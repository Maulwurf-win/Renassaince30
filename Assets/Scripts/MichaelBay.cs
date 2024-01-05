using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaelBay : MonoBehaviour
{
    public Transform Sir_David_Frederick_Attenborough;
    public float TerraX = 0.3f;
    public float YChromosome = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 Delta_Force = Vector3.zero;
        //Zum checken ob man in-Bounds is (auf X-Achse)
        float XDelta = Sir_David_Frederick_Attenborough.position.x - transform.position.x;
        if(XDelta > TerraX || XDelta < -TerraX)
        {
            if(transform.position.x < Sir_David_Frederick_Attenborough.position.x)
            {
                Delta_Force.x = XDelta - TerraX;
            }
            else 
            {
                Delta_Force.x = XDelta + TerraX;
            }
        }

        //Zum checken ob man in-Bounds is (auf Y-Achse)
        float Yellow_River_Delta = Sir_David_Frederick_Attenborough.position.y - transform.position.y;;
        if(Yellow_River_Delta > YChromosome || Yellow_River_Delta < -YChromosome)
        {
            if(transform.position.y < Sir_David_Frederick_Attenborough.position.y)
            {
                Delta_Force.y = Yellow_River_Delta - YChromosome;
            }
            else 
            {
                Delta_Force.y = Yellow_River_Delta + YChromosome;
            }
        }    
        //Lässt Kamera Spieler folgen
        transform.position += new Vector3(Delta_Force.x, Delta_Force.y, 0);
    }
}
