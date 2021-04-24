using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilCollapse : MonoBehaviour {
    #region Settings
    public Vector2 collapseSpeedMinMax = new Vector2(5f, 10f);
    public DifficultyModulator difficultyModulator = null;
    #endregion

    #region Callbacks
    void FixedUpdate() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetHealthSystem(out Health healthSystem)){
            healthSystem.Die();
        }
    }
    #endregion
}
