using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "Game/Game Manager")]
public class GameManager : ScriptableObject {
    #region Settings
    public ScoreManager scoreManager = null;
    #endregion

    #region Current
    private GameSession currentSession = null;
    #endregion

    #region Events
    public delegate void GameAction();
    public event GameAction onStartGame, onEndGame;
    #endregion

    #region Callbacks
    public void Update() {
        if (currentSession != null) {
            currentSession.Update();
        }
    }

    public void Reinitialize() {
        currentSession = null;
    }
    #endregion

    #region Game
    public void StartGame() {
        currentSession = new GameSession(scoreManager);
        currentSession.Start();
        Debug.Log("Start Game");
        onStartGame?.Invoke();
    }

    public void EndGame() {
        onEndGame?.Invoke();
    }
    #endregion
}
