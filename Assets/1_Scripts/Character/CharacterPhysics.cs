using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), DefaultExecutionOrder(-200)]
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
    [ShowNonSerializedField] private int contactsCount = 0;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        contactsCount = rigidbody.GetContacts(contacts);

        rigidbody.velocity = Vector2.zero;
        ComputeGravity();
        Debug.Log("Movement vel : " + movementVelocity);
        persistantVelocity *= (1f - GetContactsResistance(persistantVelocity.normalized));
        rigidbody.velocity += persistantVelocity + movementVelocity;

        movementVelocity = Vector2.zero;
    }
    #endregion

    #region Process Physics
    public void AddForce(Vector2 force, bool resetVelocity) {
        if (resetVelocity) {
            persistantVelocity = Vector2.zero;
        }
        persistantVelocity += force;
    }

    public void Move(Vector2 direction) {
        movementVelocity += direction * (1f - GetContactsResistance(direction.normalized));
    }

    private void ComputeGravity() {
        if(persistantVelocity.y <= 0f) {
            persistantVelocity.y = (persistantVelocity.y + fallGravityForce * Time.fixedDeltaTime);
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
        float resistance = 0f;
        if(contactsCount != 0f) {
            resistance = 0f;
            for (int i = 0; i < contactsCount; i++) {
                resistance = Mathf.Max(Vector2.Dot(contacts[i].normal, -direction), resistance);
            }
        }

        return resistance;
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
