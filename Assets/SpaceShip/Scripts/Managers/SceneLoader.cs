using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MadeInHouse.Translate;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        LanguageManager.Initialize();
    }
    
    public void LoadScene(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void LoadMenuTimer(float time)
    {
        Invoke("LoadMenu", time);
    }

    private void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
