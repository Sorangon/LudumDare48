using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), DefaultExecutionOrder(200)]
public class CharacterPhysics : MonoBehaviour {
    #region Settings
    [Header("Gravity")]
    public float resistanceGravityForce = -10f;
    public float fallGravityForce = -9.81f;
    public float maxGravity = -30f;

    [Header("References")]
    public new Rigidbody2D rigidbody = null;
    #endregion

    #region Currents
    private Vector2 movementVelocity = Vector2.zero;
    private Vector2 persistantVelocity = Vector2.zero;
    private ContactPoint2D[] contacts = new ContactPoint2D[10];
    private int contactsCount = 0;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        rigidbody.velocity = Vector2.zero;
        ComputeGravity();
        rigidbody.velocity += persistantVelocity + movementVelocity;
        contactsCount = 0;
        movementVelocity = Vector2.zero;
    }
    #endregion

    #region Process Physics
    public void AddForce(Vector2 force) {
        persistantVelocity += force;
    }

    public void Move(Vector2 direction) {
        movementVelocity += direction;
    }

    private void ComputeGravity() {
        if(persistantVelocity.y <= 0f) {
            persistantVelocity.y = (persistantVelocity.y + fallGravityForce * Time.fixedDeltaTime) * (1 - GetContactsResistance(Vector2.down));
            if(persistantVelocity.y <= maxGravity) {
                persistantVelocity.y = maxGravity;
            }
        } else {
            persistantVelocity.y = (persistantVelocity.y + resistanceGravityForce * Time.fixedDeltaTime);
        }
    }
    #endregion

    #region Physics Infos
    public float GetContactsResistance(Vector2 direction) {
        float resistance;
        if(contactsCount != 0f) {
            resistance = 1f;
            for (int i = 0; i < contactsCount; i++) {
                resistance *= Vector2.Dot(contacts[i].normal, -direction);
            }
        } else {
            resistance = 0f;
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
        Gizmos.color = Color.red;
        for (int i = 0; i < contactsCount; i++) {
            Gizmos.DrawRay(contacts[i].point, contacts[i].normal);
        }
    }
    #endregion
}
