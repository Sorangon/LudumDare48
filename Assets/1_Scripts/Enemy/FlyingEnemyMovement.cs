using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour {
    #region Settings
    [Header("Movements")]
    public float movementSpeed = 8f;
    public float movementAcceleration = 0.1f;
    public float movementDrift = 0.2f;
    public float maxFollowDistance = 8f;

    [Header("References")]
    public PositionVariable targetPosition = null;
    public new Rigidbody2D rigidbody = null;
    #endregion

    #region Currents
    private float currentMovementAmount = 0f;
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        if (MustFollow()) {
            currentMovementAmount = Mathf.Lerp(currentMovementAmount, 1f, Time.fixedDeltaTime / movementAcceleration);
        } else {
            currentMovementAmount = Mathf.Lerp(currentMovementAmount, 0f, Time.fixedDeltaTime / movementDrift);
        }

        Vector3 direction = (targetPosition.position - transform.position).normalized;
        rigidbody.velocity = direction * currentMovementAmount * movementSpeed;
    }
    #endregion


    #region Utility
    private bool MustFollow() {
        return (targetPosition.position - transform.position).sqrMagnitude < (maxFollowDistance * maxFollowDistance);
    }
    #endregion

    #region Debug
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxFollowDistance);
    }
    #endregion
}
