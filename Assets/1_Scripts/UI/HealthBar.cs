using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Settings

    [Header("Variables")]
    public IntVariable playerHealthVariable = null;
    public IntVariable playerMaxHealthVariable = null;

    [Header("UI")]
    public Slider slider = null;
    public Image fillImage = null;

    public UnityEvent onUpdateHealth = new UnityEvent();
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
        onUpdateHealth?.Invoke();
    }
    private void OnUpdateMaxHealth() {
        slider.maxValue = playerMaxHealthVariable.GetValue();
    }
    #endregion
}
