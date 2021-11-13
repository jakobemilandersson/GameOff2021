using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Speed : Upgrade
{
    public override void ApplyUpgradeEffect(GameObject _player) 
    {
        PlayerStats _playerStats = _player.GetComponent<PlayerStats>();
        _playerStats.SetSpeedMulitplier(_value, _duration);
    }
}
