using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikea : MicahBell
{
    [SerializeField] private float[] KöttbullarGeschwindigkeit = { 2.5f, -2.5f };
    [SerializeField] private float Stockholm = 0.25f;
    [SerializeField] private Transform[] Köttbullars;

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < Köttbullars.Length; i++)
        {
            Köttbullars[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * KöttbullarGeschwindigkeit[i]) * Stockholm, Mathf.Sin(Time.time * KöttbullarGeschwindigkeit[i]) * Stockholm, 0);
        }
    }
}
