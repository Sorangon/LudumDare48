using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
public class Projectile : MonoBehaviour {
    #region Settings
    [Min(0)] public int damages = 10;

    [Foldout("Events")]
    public UnityEvent onImpact = new UnityEvent();
    #endregion

    #region Physic Callbacks
    private void OnTriggerEnter2D(Collider2D collision) {
        //Check collision with damageable object
        if(collision.TryGetHealthSystem(out Health healthSystem)) {
            healthSystem.InflictDamages(damages);
        }

        onImpact?.Invoke();
        Destroy(gameObject);
    }
    #endregion
}
