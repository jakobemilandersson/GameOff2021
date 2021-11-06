using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class Upgrade : MonoBehaviour
{
    public float _value;
    [Tooltip("Duration of upgrade.")]
    public float _duration;
    [Tooltip("Text to show on upgrade object.")]
    public string _text;
    private float _rotationSpeed = 100f;

    void Start() 
    {
        foreach(Text text in GetComponentsInChildren<Text>())
        {
            text.text = _text;
        }
    }
    

    void Update()
    {
        transform.Rotate(Vector3.back * ( _rotationSpeed * Time.deltaTime ));
    }

    void OnTriggerEnter(Collider other) {
        GameObject CollidingRootObject = other.transform.root.gameObject;
        if(CollidingRootObject.tag == "Player")
        {
            OnPlayerPickUp(CollidingRootObject);
        }
    }

    void OnPlayerPickUp(GameObject _player)
    {
        ApplyUpgradeEffect(_player);

        // Destroy the root
        Destroy(this.transform.root.gameObject);
    }

    public virtual void ApplyUpgradeEffect(GameObject _player) 
    {
        Debug.Log("Upgrade: " + gameObject.name + " has no implemented effect on player?");
    }
}
