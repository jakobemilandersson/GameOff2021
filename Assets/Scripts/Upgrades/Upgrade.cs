using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public enum UpgradeType {
    SpeedIncrement
};

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private UpgradeType _type;
    [SerializeField]
    private float _value = 2f;
    [SerializeField]
    private float _duration = 5f;

    private float _rotationSpeed = 100f;
    
    
    void Update()
    {
        transform.Rotate(Vector3.back * ( _rotationSpeed * Time.deltaTime ));
    }

    void OnTriggerEnter(Collider other) {
        GameObject CollidingRootObject = other.transform.root.gameObject;
        if(CollidingRootObject.tag == "Player")
        {
            Debug.Log("[Upgrade, OnTriggerEneter] other: " + other.gameObject.name);
            OnPlayerPickUp(CollidingRootObject);
        }
    }

    void OnPlayerPickUp(GameObject _player)
    {
        Debug.Log("[Upgrade, OnPlayerPickUp]");
        SetPlayerStatFromUpgradeType(_player);
        // Destroy the root
        Destroy(this.transform.root.gameObject);
    }

    void SetPlayerStatFromUpgradeType(GameObject _player)
    {
        Debug.Log("[Upgrade, SetPlayerStatFromUpgradeType]");
        // This doesn't seem like the right approach, would be better to do this within the parent instead
        // but i'll leave it here for now and we can figure out a better and more dynamic approach
        PlayerStats _playerStats = _player.GetComponent<PlayerStats>();
        switch(_type)
        {
            case UpgradeType.SpeedIncrement:
            _playerStats.SetSpeedMulitplier(_value, _duration);
                break;
            default:
                Debug.Log("UpgradeType: " + _type.ToString() + " has no implemented effect on player?");
                break;
        }
    }
}
