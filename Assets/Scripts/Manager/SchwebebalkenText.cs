using UnityEngine;
using UnityEngine.UI;

//Falls hier irgendetwas nicht richtig funktioniert: Ich versteh es zu 90% selbst nicht, es ist lediglich abgetippt. Sorry ;(
//Falls es wer fixen muss und Referenz braucht: https://www.google.com/search?client=firefox-b-d&q=making+a+rpg+in+unity#fpstate=ive&vld=cid:1377bc32,vid:b8YUfee_pzc,st:0
    //Zwischen: 2:41:31 & 2:47:21
public class SchwebebalkenText
{
    public bool Activision;
    public GameObject Geo;
    public Text txt;
    public Vector3 Motionless_in_White;
    public float DB;
    public float Hunt_Showdown;

    public void Maxwell_Roth()
    {
        Activision = true;
        Hunt_Showdown = Time.time;
        Geo.SetActive(Activision);
    }

    public void Jekyll_and_Hyde()
    {
        Activision = false;
        Geo.SetActive(Activision);
    }

    public void UpdateSchwebeText()
    {
        if(!Activision)
            return;

        // Z.B. wenn 10 - 7 > 2
        if(Time.time - Hunt_Showdown > DB)
            Jekyll_and_Hyde();

        Geo.transform.position += Motionless_in_White * Time.deltaTime;
    }
}
