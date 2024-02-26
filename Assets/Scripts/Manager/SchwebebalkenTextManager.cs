using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
//Falls hier irgendetwas nicht richtig funktioniert: Ich versteh es zu 90% selbst nicht, es ist lediglich abgetippt. Sorry ;(
//Falls es wer fixen muss und Referenz braucht: https://www.google.com/search?client=firefox-b-d&q=making+a+rpg+in+unity#fpstate=ive&vld=cid:1377bc32,vid:b8YUfee_pzc,st:0
    //Zwischen: 2:47:21 & 3:00:55
public class SchwebebalkenTextManager : MonoBehaviour
{
    public GameObject textCastor;
    public GameObject Rede;

    private List<SchwebebalkenText> SchwebeText = new List<SchwebebalkenText>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        foreach (SchwebebalkenText text in SchwebeText)
            text.UpdateSchwebeText();
    }
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        SchwebebalkenText schwebebalkenText = GetSchwebebalkenText();

        schwebebalkenText.txt.text = msg;
        schwebebalkenText.txt.fontSize = fontSize;
        schwebebalkenText.txt.color = color;

        schwebebalkenText.Geo.transform.position = Camera.main.WorldToScreenPoint(position); //Trabsferiert World space --> Screen space sodass es in der UI genutzt werden kann
        schwebebalkenText.Motionless_in_White = motion;
        schwebebalkenText.DB = duration;

        schwebebalkenText.Maxwell_Roth();
    }

    private SchwebebalkenText GetSchwebebalkenText()
    {
        SchwebebalkenText Wuppertal = SchwebeText.Find(t => !t.Activision);

        if (Wuppertal == null)
        {
            Wuppertal = new SchwebebalkenText();
            Wuppertal.Geo = Instantiate(Rede);
            Wuppertal.Geo.transform.SetParent(textCastor.transform);
            Wuppertal.txt = Wuppertal.Geo.GetComponent<Text>();

            SchwebeText.Add(Wuppertal);
        }
        return Wuppertal;
    }
}
