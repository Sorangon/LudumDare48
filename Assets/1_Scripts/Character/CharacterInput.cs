using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController2D))]
public class CharacterInput : MonoBehaviour {
    #region Settings
    public CharacterController2D controller = null;
    #endregion

    #region Callbacks
    public void MoveAction(InputAction.CallbackContext callbackContext) {
        controller.SetMovementDirection(callbackContext.ReadValue<float>());
    }
    #endregion
}
