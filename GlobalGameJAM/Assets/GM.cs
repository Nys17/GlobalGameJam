using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM : MonoBehaviour
{
    public TextMeshProUGUI t;
    void Update()
    {
        t.text = "Score: " + PlayerPrefs.GetInt("CurrentScore");
    }
}
