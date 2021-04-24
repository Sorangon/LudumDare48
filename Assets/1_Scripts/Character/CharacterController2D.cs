using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using 

[RequireComponent(typeof(CharacterPhysics)), SelectionBase]
public class CharacterController2D : MonoBehaviour {
    #region Settings
    [Header("Movement")]
    [Min(0f)] public float movementSpeed = 8f;

    [Header("References")]
    public CharacterPhysics characterPhysics = null;
    #endregion

    #region Currents
    private float horizontalMovement = 0f;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        characterPhysics.Move(Vector2.right * horizontalMovement);
    }
    #endregion

    #region Movement
    public void SetMovementDirection(float axisDirection) {
        horizontalMovement = axisDirection * movementSpeed;
    } 
    #endregion
}
