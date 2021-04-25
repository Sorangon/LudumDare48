using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Utility/Variables/Int")]
public class IntVariable : ScriptableObject {
    #region Events
    public delegate void VariableAction();
    public event VariableAction onVariableUpdated;
    #endregion

    #region MyRegion
    [SerializeField] private int value;
    #endregion

    #region Properties
    public float GetValue() {
        return value;
    }

    public void SetValue(int val) {
        value = val;
        onVariableUpdated?.Invoke();
    }
    #endregion

    #region Callbacks
    private void OnValidate() {
        onVariableUpdated?.Invoke();
    }
    #endregion
}
