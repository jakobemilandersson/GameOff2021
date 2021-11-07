using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Jump : Upgrade
{
    public override void ApplyUpgradeEffect(GameObject _player) 
    {
        PlayerStats _playerStats = _player.GetComponent<PlayerStats>();
        _playerStats.SetJumpHeigthMulitplier(_value, _duration);
    }
}
