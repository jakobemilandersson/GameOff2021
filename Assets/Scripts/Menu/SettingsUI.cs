using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider mouseSensitivySlider;
    public TMP_InputField mouseSensitivityInput;
    public float minSensitivty = 0.1f;
    public float maxSensitivity = 5f;

    [SerializeField]
    private float _mouseSensitivity;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMouseSensitivitySlider()
    {
        mouseSensitivityInput.text = mouseSensitivySlider.value.ToString();
    }
    
    public void OnMouseSensitivityInput()
    {
        float _value = minSensitivty; // Default is 1f, used if we can't parse
        float.TryParse(mouseSensitivityInput.text, out _value);
        Debug.Log("Value: " + _value);
        if(_value > maxSensitivity)
        {
            _value = maxSensitivity;
            mouseSensitivityInput.text = _value.ToString();
        }
        _value = Mathf.Round(_value * 100f) / 100f; // round it to 2DP (e.g 1.2312312312 -> 1.23)
        mouseSensitivySlider.value = _value;
        _mouseSensitivity = _value;
    }
    
    public void OnMouseSensitivityInputEnd()
    {
        float _value;
        float.TryParse(mouseSensitivityInput.text, out _value);
        if(_value < minSensitivty)
        {
            mouseSensitivityInput.text = minSensitivty.ToString();
            mouseSensitivySlider.value = minSensitivty;
            _mouseSensitivity = minSensitivty;
        }
    }
}
