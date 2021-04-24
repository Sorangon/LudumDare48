using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    #region Settings
    [Header("References")]
    public TextMeshProUGUI scoreTextField = null;
    public ScoreManager scoreManager = null;
    #endregion

    #region Callbacks
    private void OnEnable() {
        scoreManager.onAddPoints += OnUpdateScore;
        scoreManager.onResetScore += OnUpdateScore;
        OnUpdateScore();
    }

    private void OnDisable() {
        scoreManager.onAddPoints -= OnUpdateScore;
        scoreManager.onResetScore -= OnUpdateScore;
    }
    #endregion

    #region Events
    private void OnUpdateScore() {
        scoreTextField.text = scoreManager.CurrentScore.ToString();
    }
    #endregion
}
