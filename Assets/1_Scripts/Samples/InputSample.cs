using UnityEngine;
using UnityEngine.InputSystem;

public class InputSample : MonoBehaviour {
    public void OnAction(InputAction.CallbackContext callbackContext) {
        if (callbackContext.action.phase == InputActionPhase.Started) {
            Debug.Log("Start Action");
        }

        if (callbackContext.action.phase == InputActionPhase.Canceled) {
            Debug.Log("Released Action");
        }
    }

    public void OnMove(InputAction.CallbackContext callbackContext) {
        Debug.Log($"Set Movement Direction | {callbackContext.ReadValue<Vector2>()}");
    }

    public void OnUpdatePointer(InputAction.CallbackContext callbackContext) {
        Debug.Log($"Set Pointer position | {callbackContext.ReadValue<Vector2>()}");
    }
}
