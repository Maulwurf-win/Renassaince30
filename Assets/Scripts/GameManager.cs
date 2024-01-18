using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resourcen
    public List<Sprite> SpielerSprites;
    public List<Sprite> WaffenSprites;
    public List<int> Waffenpreise;
    public List<int> XPTabelle;

    //Refeeremzen
    public Fu�baller player;

    //Logik
    public int Gulden;
    public int Lebenserfahurng;

    //Spielstand
    /*
     * Ben�tigter Kram (erstma):
     * Int Ausgew�hlter Skin
     * Int Gulden
     * Int Erfahrung
     * Int Waffenlevel (Maybe?)
     */ 
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += Gulden.ToString() + "|";
        s += Lebenserfahurng.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("Spielstand", s);
        Debug.Log("Saving Pizza Planet");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("Spielstand"))
            return;

        string[] data = PlayerPrefs.GetString("Spielstand").Split('|');

        //Skinwechsel (In Planung [Ich erstell sicher keine eigenen, also bleibts erstma offen])
        Gulden = int.Parse(data[1]);
        Lebenserfahurng = int.Parse(data[2]);
        //Waffenlevel erh�hen (In Planung)

        Debug.Log("L�dt, bitte warten");
    }
}
