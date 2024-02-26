using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikea : MicahBell
{
    [SerializeField] private float[] K�ttbullarGeschwindigkeit = { 2.5f, -2.5f };
    [SerializeField] private float Stockholm = 0.25f;
    [SerializeField] private Transform[] K�ttbullars;

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < K�ttbullars.Length; i++)
        {
            K�ttbullars[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * K�ttbullarGeschwindigkeit[i]) * Stockholm, Mathf.Sin(Time.time * K�ttbullarGeschwindigkeit[i]) * Stockholm, 0);
        }
    }
}
