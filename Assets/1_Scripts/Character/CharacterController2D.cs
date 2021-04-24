using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterPhysics)), SelectionBase]
public class CharacterController2D : MonoBehaviour {
    #region Settings
    [Header("Movement")]
    [Min(0f)] public float movementSpeed = 8f;

    [Header("Jump")]
    [Min(0f)] public float jumpForce = 10f;
    [Min(0)] public int airJumpsCount = 1;
    [Min(0f)] public float airJumpForce = 5f;

    [Header("Miscs")]
    [Range(0f, 90f)] public float isGroundedAngleThreshold = 10f;
    [Min(0f)] public float leaveGroundDelay = 0.1f;

    [Header("References")]
    public CharacterPhysics characterPhysics = null;
    #endregion

    #region Currents
    private float isGroundedTimer = 0f;
    private float horizontalMovement = 0f;
    private int remaningAirJumpCount = 0;
    private bool requestJump = false;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        characterPhysics.Move(Vector2.right * horizontalMovement);

        float groundAngle = (characterPhysics.GetContactsResistance(Vector2.down)) * 90f;
        if (groundAngle > isGroundedAngleThreshold) {
            isGroundedTimer = leaveGroundDelay;
            if(remaningAirJumpCount < airJumpsCount) {
                remaningAirJumpCount = airJumpsCount;
            }
        } else {
            if(isGroundedTimer > 0f) {
                isGroundedTimer -= Time.fixedDeltaTime;
            }
        }

        if (requestJump) {
            if (IsGrounded()) {
                characterPhysics.AddForce(Vector2.up * jumpForce, true);
            } else {
                if(remaningAirJumpCount > 0) {
                    characterPhysics.AddForce(Vector2.up * airJumpForce, true);
                    remaningAirJumpCount--;
                }
            }
            requestJump = false;
        }
    }
    #endregion

    #region Movement
    public void SetMovementDirection(float axisDirection) {
        horizontalMovement = axisDirection * movementSpeed;
    }
    #endregion

    #region Actions
    public void Jump() {
        requestJump = true;
    }
    #endregion

    #region Infos
    public bool IsGrounded() {
        return isGroundedTimer > 0f;
    }
    #endregion
}
