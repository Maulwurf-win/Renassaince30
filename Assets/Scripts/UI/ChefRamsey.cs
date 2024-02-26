using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChefRamsey : MonoBehaviour
{
    public GameObject GMan;
    [SerializeField] Button _startGame;
    [SerializeField] Button _options;
    [SerializeField] Button _credits;
    [SerializeField] Button _endGame;
    //Scene scene = SceneManager.GetActiveScene();

    // Start is called before the first frame update
    void Start()
    {
        _startGame.onClick.AddListener(Oxenfree);
        _options.onClick.AddListener(MrFreeman);
        _credits.onClick.AddListener(Further);
        _endGame.onClick.AddListener(Titanic);
    }

    public void Oxenfree()
    {
        ScenesManager.Instance.LoadMain();
    }

    /*private void StarBestimmteSzene()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level_1)
    } Falls man eine ganz bestimmte Szene laden würde wollen*/
    private void MrFreeman()
    {
        GMan.SetActive(true);
    }

    void Further()
    {
        print("Brian Tyler");
        //ScenesManager.Instance.LoadRandom();
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Credits);
    }

    void Titanic()
    {
        Application.Quit();
        Debug.Log("NO JACK!!");
        //Just to make sure its working
    }
}
