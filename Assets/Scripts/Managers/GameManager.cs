using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StarterAssets;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class GameManager : MonoBehaviour
{
    #region Instance Variable
    public static GameManager _instance;
    #endregion

    #region Pause Menu
    public bool isPaused = false;
    public GameObject pauseMenu;
    #endregion

    #region Player
    public GameObject _player;
    private StarterAssetsInputs _inputs;
    #endregion

    void Awake() {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        // Get Player
        _player = GameObject.FindGameObjectWithTag("Player");
        _inputs = _player.GetComponent<StarterAssetsInputs>();
    }

    #region Paus Menu Logic
    public bool UpdateIsPaused()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            // Set InputSystem to dynamic since it will not work when Time.timeScale = 0
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        } else {
            // Reset InputSystem to Fixed update
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

        return isPaused;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        _inputs.OnGameMenu();
    }

    #endregion
}
