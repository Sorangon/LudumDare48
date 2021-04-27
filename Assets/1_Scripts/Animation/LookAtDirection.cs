using UnityEngine;

public class LookAtDirection : MonoBehaviour {
    #region Settings
    [Range(0f, 360f)] public float offset = 0f;
    [Range(0f, 1f)] public float amount = 1f;
    public bool mirrorVertical = false;
    [Min(0f)]public float damping = 0.1f;
    #endregion

    #region Currents
    private Vector2 oldPos = Vector2.zero;
    #endregion

    private void OnEnable() {
        oldPos = transform.position;
    }

    #region Callbacks
    private void Update() {
        Vector2 vel = oldPos - (Vector2)transform.position;

        float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        //if (mirrorVertical) {
        //    angle /= 90f;
        //    //angle = Mathf.Abs(angle % 1f);
        //    angle = Mathf.Abs(1f - angle);
        //    angle = 1 - Mathf.Abs(angle);
        //    angle *= 90f;
        //}

        Quaternion rot = Quaternion.AngleAxis(angle * amount + offset, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime / damping);

        oldPos = transform.position;
    }
    #endregion
}
