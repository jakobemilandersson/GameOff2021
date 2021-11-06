using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public bool isPaused = false;
    public GameObject pausMenu;

    void Awake() {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void UpdateIsPaused()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            // Set InputSystem to dynamic since it will not work when Time.timeScale = 0
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
            Time.timeScale = 0;
            pausMenu.SetActive(true);
        } else {
            // Reset InputSystem to Fixed update
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
            Time.timeScale = 1;
            pausMenu.SetActive(false);
        }
    }
}
