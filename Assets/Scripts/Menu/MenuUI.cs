using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public string GameSceneName;
    public string SettingsSceneName;
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    public void OnSettingsButton ()
    {
        SceneManager.LoadScene(SettingsSceneName);
    }

    public void OnExitButton ()
    {
        Application.Quit();
    }
}
