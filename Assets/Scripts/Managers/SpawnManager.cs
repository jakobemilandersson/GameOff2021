using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    #region Spawn Points and Variables
    [SerializeField]
    private GameObject[] _spawnPointsEnemy;
    private string _spawnPointEnemyTagName = "SpawnPointEnemy";
    public float minSpawnableDistanceToPlayer = 1f; // Default to 1m
    public bool useMinDistanceToPlayer = true;
    #region debug
    public float debugEnemySpawnTimerThreshold;
    private float debugEnemySpawnTimer;
    public bool debugEnemySpawn = false;
    #endregion
    #endregion

    #region Player
    [SerializeField]
    private Transform _playerTransform;
    private string _playerTag = "Player";
    #endregion

    #region Enemy Prefabs
    public GameObject _cubeEnemyPrefab;
    #endregion

    void Start() {
        // Get Player transform, used for calculating spawnable spawnpoints
        _playerTransform = GameObject.FindGameObjectWithTag(_playerTag).transform;
        // Find all enemy spawn points located on map
        _spawnPointsEnemy = GameObject.FindGameObjectsWithTag(_spawnPointEnemyTagName);
        if(_spawnPointsEnemy.Length == 0)
        {
            Debug.LogError("[GameManager => Spawn Manager] No spawn points are visible in the scene?");
        }
#if UNITY_EDITOR
        // Check if _cubeEnemyPrefab has been set, if not then quit playmode
        if(_cubeEnemyPrefab == null)
        {
            Debug.LogError("[GameManager => Spawn Manager] missing Prefab assignment for '_cubeEnemyPrefab'. Add it in the Inspector.");
            UnityEditor.EditorApplication.isPlaying = false;
        }

        if(debugEnemySpawn)
        {
            if(debugEnemySpawnTimerThreshold <= 0)
            {
                Debug.LogError("[GameManager => Spawn Manager] 'debugEnemySpawnTimerThreshold' must be greater than 0 for your PC's health.");
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
#endif
        // Debug setup
        debugEnemySpawnTimer = Time.time;
    }

    void FixedUpdate() {
        if(debugEnemySpawn)
        {
            float _time = Time.time;
            if(_time > debugEnemySpawnTimer + debugEnemySpawnTimerThreshold)
            {
                debugEnemySpawnTimer = _time;
                SpawnEnemyOnRandomSpawn(_cubeEnemyPrefab, useMinDistanceToPlayer);
            }
        }    
    }

    #region Spawn Logic

    public List<GameObject> GetSpawnableSpawnPoints()
    {
        List<GameObject> _spawnablePoints = new List<GameObject>();
        foreach(GameObject _spawnPoint in _spawnPointsEnemy)
        {
            if(Vector3.Distance(_playerTransform.position, _spawnPoint.transform.position) > minSpawnableDistanceToPlayer)
            {
                _spawnablePoints.Add(_spawnPoint);
            }
        }
        return _spawnablePoints;
    }
    public void SpawnEnemyOnRandomSpawn(GameObject _enemyPrefab, bool _useMinDistance)
    {
        if(_useMinDistance)
        {
            List<GameObject> _spawnablePoints = GetSpawnableSpawnPoints();
            if(_spawnablePoints.Count > 0)
                SpawnEnemy(_enemyPrefab, _spawnablePoints[Random.Range(0, _spawnablePoints.Count)]);
        } else {
            // Randomly selects any of the spawn points in the scene
            if(_spawnPointsEnemy.Length > 0)
                SpawnEnemy(_enemyPrefab, _spawnPointsEnemy[Random.Range(0, _spawnPointsEnemy.Length)]);
        }
    }
    public void SpawnEnemy(GameObject _enemyPrefab, GameObject _spawnPoint)
    {
        Instantiate(_enemyPrefab, _spawnPoint.transform.position, Quaternion.identity);
    }
    #endregion
}
