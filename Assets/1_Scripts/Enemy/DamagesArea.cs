using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesArea : MonoBehaviour {
    #region Settings
    public int damages = 50;
    public float areaRadius = 2f;
    public float knockbackForce = 2f;
    public LayerMask targetLayer = new LayerMask();
    #endregion

    #region Callbacks
    private void FixedUpdate() {
        Collider2D col = Physics2D.OverlapCircle(transform.position, areaRadius, targetLayer);
        if (!ReferenceEquals(col, null)) {
            if (col.TryGetComponentOnRoot(out Health health)) {
                if (knockbackForce > 0 && !health.IsRecovering) {
                    if(col.TryGetComponentOnRoot(out CharacterPhysics charaPhys)){
                        Vector2 dir = col.transform.position - transform.position;
                        if(dir.y < 0f) {
                            dir.y = -dir.y * 0.2f;
                        }
                        charaPhys.AddForce(dir.normalized * knockbackForce, true);
                    }
                }

                health.InflictDamages(damages);
            }

        }
    }
    #endregion

    #region Debug
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
    }
    #endregion
}
