using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndDestroy : Soviet
{
    protected override void Trotsky()
    {
        Destroy(gameObject);
    }
}
