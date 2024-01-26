using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    #region Variables

    private PlayerControls inputs;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;

    #endregion

    #region Init

    private void Awake()
    {
        inputs = new PlayerControls();
        inputs.Gameplay.OpenUI.performed += ctx => OpenMenu();
        inputs.UI.CloseUI.performed += ctx => CloseMenu();
    }

    private void OnEnable()
    {
        inputs.Gameplay.OpenUI.Enable();
    }

    private void OnDisable()
    {
        inputs.Gameplay.OpenUI.Disable();
    }

    #endregion

    #region Custom Methods

    private void OpenMenu()
    {
        mainPanel.SetActive(true);
        inputs.Gameplay.OpenUI.Disable();
        inputs.UI.CloseUI.Enable();
        inputs.Gameplay.Disable();
    }

    public void CloseMenu()
    {
        mainPanel.SetActive(false);
        inputs.Gameplay.OpenUI.Enable();
        inputs.UI.CloseUI.Disable();
        inputs.Gameplay.Enable();
    }

    public void OpenOptions()
    {
        mainPanel.SetActive(false);

    }

    public void CloseOptions()
    {
        mainPanel.SetActive(true);
    }

    #endregion
}
