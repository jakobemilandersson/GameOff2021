using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    // -----------------    PRIVATE VARIABLES    -----------------
    #region Private Variables
    [SerializeField]
    private float _mouseSensitivity;

    #endregion

    // -----------------    PUBLIC VARIABLES    -----------------
    #region Public Variables
    // Main Menu Scene Name
    public string MainMenuSceneName = "MenuScreen";

    #region Mouse Sensitivity
    public Slider mouseSensitivySlider;
    public TMP_InputField mouseSensitivityInput;
    public float minMouseSensitivty = 0.01f;
    public float maxMouseSensitivity = 5f;
    public float defaultMouseSensitivity = 1f;
    #endregion

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        TryFetchAndSetPlayerPrefs();
    }

    void TryFetchAndSetPlayerPrefs()
    {
        // Try to get the players stored settings
        if(PlayerPrefs.HasKey(PlayerPrefsKeys.mouseSensitivity.ToString()))
        {
            _mouseSensitivity = PlayerPrefs.GetFloat(PlayerPrefsKeys.mouseSensitivity.ToString());
        } else {
            _mouseSensitivity = defaultMouseSensitivity;
        }

        // Set all slider/input values now
        mouseSensitivityInput.text = _mouseSensitivity.ToString();
        mouseSensitivySlider.value = _mouseSensitivity;
    }

    public void OnMouseSensitivitySlider()
    {
        float _value = Mathf.Round(mouseSensitivySlider.value * 100f) / 100f; // round it to 2DP (e.g 1.2312312312 -> 1.23)
        _mouseSensitivity = _value;
        mouseSensitivySlider.value = _value;
        mouseSensitivityInput.text = _value.ToString();
    }

    public void OnMouseSensitivityInputEnd()
    {
        float _value;
        float.TryParse(mouseSensitivityInput.text, out _value);
        if(_value < minMouseSensitivty)
        {
            _value = minMouseSensitivty;
        } else if(_value > maxMouseSensitivity)
        {
            _value = maxMouseSensitivity;
            mouseSensitivityInput.text = _value.ToString();
        }
        _value = Mathf.Round(_value * 1000f) / 1000f; // round it to 3DP (e.g 1.2312312312 -> 1.231)
        mouseSensitivityInput.text = _value.ToString();
        mouseSensitivySlider.value = _value;
        _mouseSensitivity = _value;
    }

    public void OnSaveButton()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKeys.mouseSensitivity.ToString(), _mouseSensitivity);
        // Now go back to main menu
        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
}
