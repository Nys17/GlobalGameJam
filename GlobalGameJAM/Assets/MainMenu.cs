using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI t;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        t.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
    public void OnStartButton()
    {

        SceneManager.LoadScene( 1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
