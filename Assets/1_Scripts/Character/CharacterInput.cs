using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CoreDev.Utility;

[RequireComponent(typeof(CharacterController2D))]
public class CharacterInput : MonoBehaviour {
    #region Settings
    public CharacterController2D controller = null;
    public CharacterWeaponManager weaponManager = null;
    #endregion

    #region Callbacks
    public void MoveAction(InputAction.CallbackContext callbackContext) {
        controller.SetMovementDirection(callbackContext.ReadValue<float>());
    }

    public void JumpAction(InputAction.CallbackContext callbackContext) {
        if(callbackContext.action.phase == InputActionPhase.Performed) {
            controller.Jump();
        }
    }

    public void ShootAction(InputAction.CallbackContext callbackContext) {
        if(callbackContext.action.phase == InputActionPhase.Performed) {
            weaponManager.Trigger();
        }

        if(callbackContext.action.phase == InputActionPhase.Canceled) {
            weaponManager.Release();
        }
    }

    public void PointerAction(InputAction.CallbackContext callbackContext) {
        Vector2 direction = MainCameraBuffer.Get().ScreenToWorldPoint(callbackContext.ReadValue<Vector2>()) - weaponManager.weaponAnchor.transform.position;
        direction = direction.normalized;
        weaponManager.SetAimDir(direction);
    }
    #endregion
}
