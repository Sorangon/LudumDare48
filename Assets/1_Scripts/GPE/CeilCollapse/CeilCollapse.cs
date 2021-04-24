using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilCollapse : MonoBehaviour {
    #region Settings
    [Header("Settings")]
    public Vector2 nearCollapseSpeedMinMax = new Vector2(1f, 3f);
    public Vector2 farCollapseSpeedMinMax = new Vector2(5f, 10f);
    public float modulationDistance = 5f;
    public AnimationCurve modulationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [Header("References")]
    public DifficultyModulator difficultyModulator = null;
    public PositionVariable targetPos = null;
    public GameManager gameManager = null;
    #endregion

    #region Currents
    private bool isFalling = false;
    #endregion

    #region Callbacks
    private void OnEnable() {
        if (gameManager == null) {
            isFalling = true;
        } else {
            gameManager.onStartGame += OnStartGame;
            gameManager.onEndGame += OnEndGame;
        }
    }

    void FixedUpdate() {
        if (!isFalling) return;
        transform.position += Vector3.down * GetSpeed() * Time.fixedDeltaTime;
    }

    private void OnDisable() {
        if (gameManager != null) {
            gameManager.onStartGame += OnStartGame;
            gameManager.onEndGame += OnEndGame;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetHealthSystem(out Health healthSystem)){
            healthSystem.Die();
        }
    }
    #endregion

    #region Speed
    private float GetSpeed() {
        float nearSpeed = Mathf.Lerp(nearCollapseSpeedMinMax.x, nearCollapseSpeedMinMax.y, difficultyModulator.DifficultyAmount);
        float farSpeed = Mathf.Lerp(farCollapseSpeedMinMax.x, farCollapseSpeedMinMax.y, difficultyModulator.DifficultyAmount);
        return Mathf.Lerp(nearSpeed, farSpeed, modulationCurve.Evaluate(GetDistanceRatio()));
    }

    private float GetDistanceRatio() {
        return (transform.position.y - targetPos.position.y) / modulationDistance;
    }
    #endregion

    #region Debug
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.Lerp(Color.green, Color.red, modulationCurve.Evaluate(GetDistanceRatio()));
        Gizmos.DrawLine(transform.position, targetPos.position);
    }
    #endregion

    #region Events
    private void OnStartGame() {
        isFalling = true;
    }

    private void OnEndGame() {
        isFalling = false;
    }
    #endregion
}
