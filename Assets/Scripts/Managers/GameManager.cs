using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public bool isPaused = false;
    public GameObject pauseMenu;
    public UnityEvent gameMenuEvent; // TODO: Do it better, this feels super hacky...

    void Awake() {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

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
        // TODO: Set up an "ExitGameEvent" instead of manually fireing "GameMenu"-InputEvent?
        gameMenuEvent.Invoke();

        // // Reset InputSystem to Fixed update
        // InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
        // Time.timeScale = 1;
        // pauseMenu.SetActive(false);
    }
}
