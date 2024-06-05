using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM : MonoBehaviour
{
    public TextMeshProUGUI t;

    public int currentScore;

    private void Start()
    {

        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
            
        }
        currentScore = 0;
    }
    void Update()
    {
        t.text = "Score: " + currentScore;
    }
}
