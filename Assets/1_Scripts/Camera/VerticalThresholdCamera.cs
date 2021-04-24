using UnityEngine;

public class VerticalThresholdCamera : MonoBehaviour {
    #region Settings
    [Header("Settings")]
    public float damping = 1f;
    public float verticalOffset = 1f;
    public float maxDistance = 5f;

    [Header("References")]
    public Transform followTarget = null;
    #endregion

    #region Callbacks
    private void LateUpdate() {
    }
    #endregion

    #region Debug
    private void OnDrawGizmosSelected() {
        if (Application.isPlaying) {
            //Gizmos.DrawLine(-Vector3.right * )
        }
    }
    #endregion
}
