using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    void OnEnable()
    {
        pointsText.text = GameManager._instance.GetPoints().ToString();
    }
}
