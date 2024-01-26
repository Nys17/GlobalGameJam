using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Player player;

    #endregion

    #region Init

    private void Awake()
    {
        if (!TryGetComponent<TextMeshProUGUI>(out text))
            Debug.Log("No Text!");
    }

    #endregion

    private void Update()
    {
        text.text = new string("Health: " + player.PlayerHealth.ToString());
    }
}
