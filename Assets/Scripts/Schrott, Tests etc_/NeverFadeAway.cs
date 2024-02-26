using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class NeverFadeAway : MonoBehaviour
{
    /*[SerializeField] private CanvasGroup Anzeige;
    [SerializeField] private bool FadeOut = false;*/
    [SerializeField] private GameObject Johnny;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*void Update() //KP ¯\_(?)_/¯ 
    {
        if (FadeOut)
        {
            if (Anzeige.alpha >= 0)
            {
                Anzeige.alpha -= Time.deltaTime;
                if (Anzeige.alpha == 0)
                {
                    FadeOut = false;
                    Fenster.SetActive(false);
                }
            }
        }
    }*/

    /*public void Rogue()
    {
        if(Johnny != null)
        {
            Johnny.SetActive(false);
        }
    }*/
}

