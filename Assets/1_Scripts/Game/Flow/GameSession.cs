using UnityEngine;

public class GameSession {
    #region Constructors
    public GameSession(ScoreManager scoreManager, DifficultyModulator difficultyModulator) {
        this.scoreManager = scoreManager;
        this.difficultyModulator = difficultyModulator;
    }
    #endregion

    #region Currents
    private float currentGameTime = 0f;
    private ScoreManager scoreManager = null;
    private DifficultyModulator difficultyModulator = null;
    #endregion

    #region Properties
    public float CurrentGameTime => currentGameTime;
    #endregion

    #region Callbacks
    public void Start() {
        difficultyModulator.Reinitialize();
    }

    public void Stop() {
        ResetAll();
    }

    public void Update() {
        currentGameTime += Time.deltaTime;
        difficultyModulator.Update();
    }
    #endregion

    #region Manage
    private void ResetAll() {
        scoreManager.ResetScore();
        difficultyModulator.Reinitialize();
    }

    #endregion
}
