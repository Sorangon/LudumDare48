using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Settings
    [Header("Graphics")]
    public Gradient colorOverLife = new Gradient();

    [Header("Variables")]
    public IntVariable playerHealthVariable = null;
    public IntVariable playerMaxHealthVariable = null;

    [Header("UI")]
    public Slider slider = null;
    public Image fillImage = null;
    #endregion

    #region Callbacks
    private void OnEnable() {
        playerHealthVariable.onVariableUpdated += OnUpdateHealth;
        playerMaxHealthVariable.onVariableUpdated += OnUpdateMaxHealth;
    }

    private void OnDisable() {
        playerHealthVariable.onVariableUpdated -= OnUpdateHealth;
        playerMaxHealthVariable.onVariableUpdated -= OnUpdateMaxHealth;
    }

    private void OnUpdateHealth() {
        slider.value = playerHealthVariable.GetValue();
        UpdateColor();
    }
    private void OnUpdateMaxHealth() {
        slider.maxValue = playerMaxHealthVariable.GetValue();
        UpdateColor();
    }
    #endregion

    #region Color
    private void UpdateColor() {
        fillImage.color = colorOverLife.Evaluate((float)playerHealthVariable.GetValue() / (float)playerMaxHealthVariable.GetValue());
    }
    #endregion
}
