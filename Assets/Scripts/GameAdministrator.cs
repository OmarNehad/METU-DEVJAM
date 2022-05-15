using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAdministrator:MonoBehaviour
{

    public static GameAdministrator Instance;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void PlayButton()
    {

        SceneManager.LoadScene("Level_Menu");

    }

    public void Quit()
    {
        Application.Quit();
    }


    public void Level1()
    {

        SceneManager.LoadScene("Level1");

    }

    public void Level2()
    {

        SceneManager.LoadScene("Level2");

    }





}