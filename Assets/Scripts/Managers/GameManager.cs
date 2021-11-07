using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public UnityEvent gameMenuEvent; // TODO: Do it better, this feels super hacky...
    #endregion

    #region Spawn Points
    [SerializeField]
    private GameObject[] _spawnPointsEnemy;
    private string _spawnPointEnemyTagName = "SpawnPointEnemy";
    #endregion

    #region Enemy Prefabs
    public GameObject _cubeEnemyPrefab;
    #endregion

    void Awake() {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start() {
        // Find all enemy spawn points located on map
        _spawnPointsEnemy = GameObject.FindGameObjectsWithTag(_spawnPointEnemyTagName);

        foreach(GameObject _spawnPoint in _spawnPointsEnemy)
        {
            SpawnEnemy(_cubeEnemyPrefab, _spawnPoint);
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

    #region Spawn Logic
    public void SpawnEnemy(GameObject _enemyPrefab, GameObject _spawnPoint)
    {
        Instantiate(_enemyPrefab, _spawnPoint.transform.position, Quaternion.identity);
    }
    #endregion

    #region Paus Menu Logic

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        // TODO: Set up an "ExitGameEvent" instead of manually fireing "GameMenu"-InputEvent?
        gameMenuEvent.Invoke();
    }

    #endregion
}
