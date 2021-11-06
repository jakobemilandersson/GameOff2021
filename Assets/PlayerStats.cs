using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerStats : MonoBehaviour
{

    private float _defaultSpeed;

    public FirstPersonController _FirstPersonController;


    void Start() {
        _defaultSpeed = _FirstPersonController.GetDefaultSpeed();    
    }

    public void SetSpeedMulitplier(float _multiplier, float _duration)
    {
        float _speed = _FirstPersonController.MoveSpeed * _multiplier;
        UpdatePlayerControllerSpeed(_speed);
        Invoke("ResetSpeedMultiplier", _duration);
    }

    void ResetSpeedMultiplier()
    {
        UpdatePlayerControllerSpeed(_defaultSpeed);
    }

    void UpdatePlayerControllerSpeed(float _speed)
    {
        _FirstPersonController.MoveSpeed = _speed;
    }
}
