using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benny : Fixer
{
    private void FixedUpdate()
    {
        float XPath = Input.GetAxisRaw("Horizontal");
        float YTheory = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(XPath, YTheory, 0).normalized);
    }
}
