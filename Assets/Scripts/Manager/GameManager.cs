using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string Spawn = "SpawnPoint";
    public string Jekyll = "Hyde";

    [SerializeField] private GameObject Vegas;
    [SerializeField] private GameObject JellyBeans;
    [SerializeField] private GameObject Rollin_Air_Raid_Vehicle;
    [SerializeField] private GameObject Quick_Time_Event;
    [SerializeField] private GameObject USB_Hub;

    private void Awake()
    {
        if (GameManager.instance != null)
        { 
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(JellyBeans);
            Destroy(Rollin_Air_Raid_Vehicle);
            Destroy(USB_Hub);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Vegas);
        DontDestroyOnLoad(JellyBeans);
        DontDestroyOnLoad(Quick_Time_Event);
        DontDestroyOnLoad(USB_Hub);
    }

    //Resourcen
    public List<Sprite> SpielerSprites;
    public List<Sprite> WaffenSprites;
    public List<int> Waffenpreise;
    public List<int> XPTabelle;

    //Refeeremzen
    public Benny player;
    public ABomb weapon;
    public Spielerbogen Stats;

    public SchwebebalkenTextManager schwebebalkenTextManager;
    public RectTransform LoveCraftBar;
    public Animator ODeath;

    //Logik
    public int Gulden;
    public int Lebenserfahurng;

    //Aktivierbarer Kram
    [SerializeField] private GameObject PropagandaStyle;
    [SerializeField] private GameObject HaveFaith;

    private void Update()
    {
        RogerClark();
        //Debug.Log(MomentanesLevel());
    }

    private void RogerClark()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print(JellyBeans.activeSelf);
            if (JellyBeans.activeSelf == true)
            {
                JellyBeans.SetActive(false);
            }
            else
            {
                JellyBeans.SetActive(true);
                Stats.Terms_of_Service_Update();
            }

            /*if(Semesterferien !=)
                Semesterferien.SetActive(false);
            if(Semesterferien == null)
                Semesterferien.SetActive(true);*/
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print(PropagandaStyle.activeSelf);
            if (PropagandaStyle.activeSelf == true)
            {
                PropagandaStyle.SetActive(false);
            }
            else
            {
                PropagandaStyle.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            print(HaveFaith.activeSelf);
            if (HaveFaith.activeSelf == true)
            {
                HaveFaith.SetActive(false);
            }
            else
            {
                HaveFaith.SetActive(true);
            }
        }
    }


    //Schwebender Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        schwebebalkenTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Waffenupgrade
    public bool UpgradeVersuch()
    {
        //Checkt ob Waffe maximal geupgradet ist
        if (Waffenpreise.Count <= weapon.Innovation)
            return false;

        if(Gulden >= Waffenpreise[weapon.Innovation])
        {
            Gulden -= Waffenpreise[weapon.Innovation];
            weapon.Upgrade();
            return true;
        }

        return true;
    }

    //HP Bar
    public void BeiHitpointÄnderung()
    {
        float Ratiopharm = (float)player.Panzerung / (float)player.maxPanzerung;
        LoveCraftBar.localScale = new Vector3(1, Ratiopharm, 1);
    }

    //Erfahrungssystem
    public int MomentanesLevel()
    {
        int Level = 0;
        int NötigeXP = 0;

        while(Lebenserfahurng >= NötigeXP)
        {
            NötigeXP += XPTabelle[Level];
            Level++;

            if(Level == XPTabelle.Count) //Max level
                return Level;
        }

        return Level;
    }

    public int XPtoLevel(int level) //KP was das macht [Zur Referenz: 5:44:44 https://www.google.com/search?client=firefox-b-d&q=making+a+rpg+in+unity#fpstate=ive&vld=cid:1377bc32,vid:b8YUfee_pzc,st:0]
    {
        int r = 0;
        int xp = 0;

        while(r < level)
        {
            xp += XPTabelle[r];
            r++;
        }
        
        return xp;
    }

    public void GibXP(int xp)
    {
        int momentanLevl = MomentanesLevel();
        Lebenserfahurng += xp;
        if (momentanLevl < MomentanesLevel())
            BeiLevelAufstieg();
    }

    public void BeiLevelAufstieg()
    {
        print("Levelaufstieg");
        player.BeiLevelAufstieg();
        BeiHitpointÄnderung();
    }

    //Death Menu and Respawn
    public void Respawn()
    {
        ODeath.SetTrigger(Jekyll);
        ScenesManager.Instance.LoadMain();
        player.Respwan();
    }

    //Spielstand
    /*
     * Benötigter Kram (erstma):
     * Int Ausgewählter Skin
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
        s += weapon.Innovation.ToString();

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

        //Erfahrung
        Lebenserfahurng = int.Parse(data[2]);
        if(MomentanesLevel() == 1)
            player.LevelFestlegung(MomentanesLevel());
        //Erhöht Waffenlevel
        weapon.WaffenLevelFestlegung(int.Parse(data[3]));
        Debug.Log("Lädt, bitte warten");

        player.transform.position = GameObject.Find(Spawn).transform.position;
    }
}
