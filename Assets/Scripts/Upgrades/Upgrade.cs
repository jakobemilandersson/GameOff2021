using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class Upgrade : MonoBehaviour
{
    [Tooltip("Value of upgrade power.")]
    public float _value;
    [Tooltip("Duration of upgrade.")]
    public float _duration;
    [Tooltip("Text to show on upgrade object.")]
    public string _text;
    [Tooltip("If Upgrade object should reappear X second after pickup.")]
    public bool respawnOnPickup = false;
    [Tooltip("Number of seconds after pickup it should reappear again.")]
    public float respawnTimer = 5f;
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

        if(!respawnOnPickup)
        {
            // Destroy the root
            Destroy(this.transform.root.gameObject);
        } else {
            gameObject.SetActive(false);
            Invoke("SetActive", respawnTimer);
        }
    }

    void SetActive()
    {
        gameObject.SetActive(true);
    }

    public virtual void ApplyUpgradeEffect(GameObject _player) 
    {
        Debug.Log("Upgrade: " + gameObject.name + " has no implemented effect on player?");
    }
}
