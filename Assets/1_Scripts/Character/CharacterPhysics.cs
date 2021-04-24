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
    private float currentGravity = 0f;
    private ContactPoint2D[] contacts = new ContactPoint2D[10];
    private int contactsCount = 0;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        rigidbody.velocity = Vector2.zero;
        ComputeGravity();
        contactsCount = 0;
    }
    #endregion

    public void Move(Vector2 direction) {
        rigidbody.velocity += direction;
    }

    #region Process Physics
    private void ComputeGravity() {
        currentGravity = (currentGravity + gravityForce * Time.fixedDeltaTime) * GetContactsResistance(Vector2.down);
        if(currentGravity <= maxGravity) {
            currentGravity = maxGravity;
        }
        rigidbody.velocity += Vector2.up * currentGravity;
    }

    private float GetContactsResistance(Vector2 direction) {
        float resistance;
        if(contactsCount != 0f) {
            resistance = 1f;
            for (int i = 0; i < contactsCount; i++) {
                resistance *= 1f - Vector2.Dot(contacts[i].normal, -direction);
            }
        } else {
            resistance = 1f;
        }

        return resistance;
    }
    #endregion

    #region Physics Callbacks
    private void OnCollisionStay2D(Collision2D collision) {
        contactsCount = collision.GetContacts(contacts);
    }
    #endregion

    #region Debug
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, rigidbody.velocity);
    }
    #endregion
}
