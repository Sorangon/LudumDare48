using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterPhysics)), SelectionBase]
public class CharacterController2D : MonoBehaviour {
    #region Settings
    [Header("Movement")]
    [Min(0f)] public float movementSpeed = 8f;
    [Min(0f)] public float groundMovementAcceleration = 0.1f;
    [Min(0f)] public float airMovementAcceleration = 0.3f;
    [Min(0f)] public float groundMovementDeceleration = 0.05f;
    [Min(0f)] public float airMovementDeceleration = 0.5f;

    [Header("Jump")]
    [Min(0f)] public float jumpForce = 10f;
    [Min(0)] public int airJumpsCount = 1;
    [Min(0f)] public float airJumpForce = 5f;

    [Header("Miscs")]
    [Range(0f, 90f)] public float isGroundedAngleThreshold = 10f;
    [Min(0f)] public float leaveGroundDelay = 0.1f;

    [Header("References")]
    public CharacterPhysics characterPhysics = null;

    [Foldout("Events")]
    public UnityEvent onJump = new UnityEvent();
    [Foldout("Events")]
    public UnityEvent onLand = new UnityEvent();
    #endregion

    #region Currents
    private float isGroundedTimer = 0f;
    private float axisDirection = 0f;
    private float currentHorizontalMovement = 0f;
    private int remaningAirJumpCount = 0;
    private bool requestJump = false;
    #endregion

    #region Properties
    public float CurrentSpeed => currentHorizontalMovement;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        ManageHorizontalMovements();

        float groundAngle = (characterPhysics.GetContactsResistance(Vector2.down)) * 90f;
        if (groundAngle > isGroundedAngleThreshold) {
            if(isGroundedTimer <= 0f) {
                isGroundedTimer = leaveGroundDelay;
                remaningAirJumpCount = airJumpsCount;
                onLand?.Invoke();
            }
        } else {
            if(isGroundedTimer > 0f) {
                isGroundedTimer -= Time.fixedDeltaTime;
            }
        }

        if (requestJump) {
            if (IsGrounded()) {
                Jump(jumpForce);
            } else {
                if(remaningAirJumpCount > 0) {
                    Jump(airJumpForce);
                    remaningAirJumpCount--;
                }
            }
            requestJump = false;
        }
    }
    #endregion

    #region Movement
    public void SetMovementDirection(float axisDirection) {
        this.axisDirection = axisDirection;
    }

    private void ManageHorizontalMovements() {
        float absAxisDir = Mathf.Abs(axisDirection);

        float lerpT;
        if(absAxisDir > 0) {
            if (IsGrounded()) {
                lerpT = groundMovementAcceleration;
            } else {
                lerpT = airMovementAcceleration;
            }
        } else {
            if (IsGrounded()) {
                lerpT = groundMovementDeceleration;
            } else {
                lerpT = airMovementDeceleration;
            }
        }

        currentHorizontalMovement = Mathf.Lerp(currentHorizontalMovement, axisDirection, Time.fixedDeltaTime / lerpT);

        characterPhysics.Move(Vector2.right * currentHorizontalMovement * movementSpeed);
    }
    #endregion

    #region Actions
    public void RequestJump() {
        requestJump = true;
    }

    private void Jump(float force) {
        characterPhysics.AddForce(Vector2.up * force, true);
        onJump?.Invoke();
    }
    #endregion

    #region Infos
    public bool IsGrounded() {
        return isGroundedTimer > 0f;
    }
    #endregion
}
