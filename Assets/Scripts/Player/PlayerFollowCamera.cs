using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerFollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public string playerTag = "Player";
    public string cameraRootName = "PlayerCameraRoot";
    void Awake()
    {
        CinemachineVirtualCamera _camera = GetComponent<CinemachineVirtualCamera>();

        // Find Player object
        GameObject _player = GameObject.FindGameObjectWithTag(playerTag);
        Transform _playerCameraRoot = _player.transform.Find(cameraRootName);

        _camera.m_Follow = _playerCameraRoot; 
    }
}
