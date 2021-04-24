using UnityEngine;

public class PhysicTranslation2D : MonoBehaviour {
    #region Settings
    public Vector2 movement = Vector2.zero;
    public bool worldSpace = false;
    public new Rigidbody2D rigidbody = null;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        Vector2 dir = worldSpace ? (Vector2)movement : (Vector2)(transform.rotation * movement);
        if (rigidbody.isKinematic) {
            rigidbody.MovePosition((Vector2)transform.position + (dir * Time.fixedDeltaTime));
        } else {
            rigidbody.velocity = dir;
        }
    }
    #endregion
}
