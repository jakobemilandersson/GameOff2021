using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerStats : MonoBehaviour
{

    [Header("Movement")]
	[Tooltip("Move speed of the character in m/s")]
    public float defaultMoveSpeed = 4f;
	[Tooltip("Sprint speed of the character in m/s")]
    public float sprintMultiplier = 1.5f;
    [Space(10)]
	[Tooltip("The height the player can jump")]
    public float defaultJumpHeight = 1.2f;

    public FirstPersonController _FirstPersonController;

    #region Speed Upgrade

    public void SetSpeedMulitplier(float _multiplier, float _duration)
    {
        float _speed = _FirstPersonController.MoveSpeed * _multiplier;
        UpdatePlayerControllerSpeed(_speed);
        Invoke("ResetSpeedMultiplier", _duration);
    }

    void ResetSpeedMultiplier()
    {
        UpdatePlayerControllerSpeed(defaultMoveSpeed);
    }

    void UpdatePlayerControllerSpeed(float _speed)
    {
        _FirstPersonController.MoveSpeed = _speed;
    }

    #endregion

    #region Jump Upgrade
    
    public void SetJumpHeigthMulitplier(float _multiplier, float _duration)
    {
        float _jumpHeight = _FirstPersonController.JumpHeight * _multiplier;
        UpdatePlayerControllerJumpHeigth(_jumpHeight);
        Invoke("ResetJumpHeigthMultiplier", _duration);
    }

    void ResetJumpHeigthMultiplier()
    {
        UpdatePlayerControllerJumpHeigth(defaultJumpHeight);
    }

    void UpdatePlayerControllerJumpHeigth(float _jumpHeight)
    {
        _FirstPersonController.JumpHeight = _jumpHeight;
    }

    #endregion
}
