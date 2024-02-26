using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Main,
        House1,
        Dungeon1,
        Dungeon2,
        Credits
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(Scene.Main.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadRandom()
    {
        SceneManager.LoadScene(Scene.Credits.ToString());
    }
}
