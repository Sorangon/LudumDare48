using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    #region Currents
    private Vector2 aimDirection = Vector2.zero;
    #endregion

    #region Callbacks
    public abstract void Trigger();
    public abstract void Release();
    #endregion
}
