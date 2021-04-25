using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosiveArea : MonoBehaviour {
    #region Settings
    [Min(0f)] public float areaRadius = 1f;
    [Min(0f)] public int damages = 100;
    public float knockbackForce = 2f;
    public LayerMask targetLayers = new LayerMask();
    public bool destroy = false;

    [Foldout("Events")]
    public FloatEvent onExplode;
    #endregion

    #region Classes
    [System.Serializable] public class FloatEvent : UnityEvent<float> { }
    #endregion

    #region Currents
    private static Collider2D[] collisions = new Collider2D[40];
    #endregion

    #region Behaviour
    public void Explode() {
        gameObject.SetActive(false);

        int cols = Physics2D.OverlapCircleNonAlloc(transform.position, areaRadius, collisions, targetLayers);
        for (int i = 0; i < cols; i++) {
            if(collisions[i].TryGetHealthSystem(out Health health)) {
                health.InflictDamages(damages);
            }

            if(collisions[i].TryGetComponentOnRoot(out CharacterPhysics charaPhys)){
                Vector2 dir = collisions[i].transform.position - transform.position;
                charaPhys.AddForce(dir.normalized * knockbackForce, true);
            }
        }

        onExplode?.Invoke(areaRadius);

        if (destroy) {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Debug
    public void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
    }
    #endregion
}
