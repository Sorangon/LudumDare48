using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession {
    #region Constructors
    public GameSession(ScoreManager scoreManager) {
        this.scoreManager = scoreManager;
    }
    #endregion

    #region Currents
    private float currentGameTime = 0f;
    private ScoreManager scoreManager = null;
    #endregion

    #region Callbacks
    public void Start() {
        scoreManager.ResetScore();
    }

    public void Update() {

    }
    #endregion
}
