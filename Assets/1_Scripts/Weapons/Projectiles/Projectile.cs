using UnityEngine;

[SelectionBase]
public class Projectile : MonoBehaviour {
    #region Settings
    [Min(0)] public int damages = 10;
    #endregion

    #region Physic Callbacks
    private void OnTriggerEnter2D(Collider2D collision) {
        //Check collision with damageable object
        GameObject rootGo = collision.attachedRigidbody != null ? collision.attachedRigidbody.gameObject : collision.gameObject;
        if (rootGo.TryGetComponent(out Health health)) {
            health.InflictDamages(damages);
        }

        Destroy(gameObject);
    }
    #endregion
}
