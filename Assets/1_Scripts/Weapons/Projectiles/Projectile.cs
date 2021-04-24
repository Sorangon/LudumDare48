using UnityEngine;

[SelectionBase]
public class Projectile : MonoBehaviour {
    #region Physic Callbacks
    private void OnTriggerEnter2D(Collider2D collision) {
        //Check collision with damageable object

        Destroy(gameObject);
    }
    #endregion
}
