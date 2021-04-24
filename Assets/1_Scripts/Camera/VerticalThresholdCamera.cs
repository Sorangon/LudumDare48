using UnityEngine;

public class VerticalThresholdCamera : MonoBehaviour {
    #region Settings
    [Header("Settings")]
    [Min(0f)]public float damping = 1f;
    public float heightThreshold = -1f;
    public float maxDistance = 5f;

    [Header("References")]
    public PositionVariable target = null;
    #endregion

    #region Currents
    private float targetHeight = Mathf.Infinity;
    #endregion

    #region Callbacks
    private void Awake() {
        targetHeight = transform.position.y;
    }

    private void LateUpdate() {
        if (target == null) return;

        if (target.position.y <= targetHeight + heightThreshold) {
            targetHeight = target.position.y - heightThreshold;
        }

        Vector3 targetPos = new Vector3(transform.position.x, targetHeight, transform.position.z);
        if (damping > 0) {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime / damping);
        } else {
            transform.position = targetPos;
        }
    }
    #endregion

    #region Debug
    private void OnDrawGizmosSelected() {
        void DrawVerticalLine(float height) {
            Gizmos.DrawLine(new Vector2(-500f, height), new Vector2(500f, height));
        }

        Gizmos.color = Color.green;
        DrawVerticalLine(transform.position.y + heightThreshold);

        if (Application.isPlaying) {
            Gizmos.color = Color.yellow;
            DrawVerticalLine(targetHeight + heightThreshold);

            if (target != null) {
                Gizmos.DrawSphere(target.position, 0.2f);
            }
        }
    }
    #endregion
}
