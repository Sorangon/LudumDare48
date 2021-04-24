using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "Game/Score Manager")]
public class ScoreManager : ScriptableObject {
    #region MyRegion
    public delegate void ScoreAction();
    public event ScoreAction onAddPoints, onResetScore;
    #endregion

    #region Currents
    [ShowNonSerializedField] private int currentScore = 0;
    #endregion

    #region Properties
    public int CurrentScore => currentScore;
    #endregion

    #region ManageScore
    public void ResetScore() {
        currentScore = 0;
        onResetScore?.Invoke();
    }

    public void AddPoints(int points) {
        currentScore += points;
        onAddPoints?.Invoke();
    }
    #endregion
}
