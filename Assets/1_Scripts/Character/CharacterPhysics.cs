using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPhysics : MonoBehaviour {
    #region Settings
    [Header("Gravity")]
    public float gravityForce = -9.81f;
    public float maxGravity = -30f;

    [Header("References")]
    public new Rigidbody2D rigidbody = null;
    #endregion

    #region Currents
    private Vector2 velocity = Vector3.zero;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        velocity = Vector2.zero;
        rigidbody.velocity = velocity;
    }
    #endregion

    #region Process Physics
    private void ComputeGravity() {
        //float gravity = 
    }

    private float GetGroundReistance() {
        return 0f;
    }
    #endregion
}
