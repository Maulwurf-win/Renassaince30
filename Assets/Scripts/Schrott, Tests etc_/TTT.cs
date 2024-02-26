using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTT : MicahBell
{
    public float s = 2.5f;
    public float e = 0.25f;
    public Transform t;

    // Update is called once per frame
    void Update()
    {
        //WIE BEHINDERT BIN ICH EIGNETLICH!!?!!?!?!!
        //t.transform = transform.position + new Vector3(-Mathf.Cos(Time.time * s) * e, Mathf.Sin(Time.time * s), 0);
    }
}
