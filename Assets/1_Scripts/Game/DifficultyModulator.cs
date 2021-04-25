using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "DM_", menuName = "Game/Difficulty Modulator")]
public class DifficultyModulator : ScriptableObject {
    #region Settings
    [Range(0, 1f)] public float percentageIncrementPerSeconds = 0.02f;
    [MinMaxSlider(0f, 1f)] public Vector2 minDifficultyAmount = new Vector2(0f, 1f);
    #endregion

    #region Current
    [ShowNonSerializedField] private float difficultyAmount = 0f;
    #endregion

    #region Properties
    public float DifficultyAmount => difficultyAmount;
    #endregion

    #region Difficulty
    public void Update() {
        if(difficultyAmount < 1f) {
            difficultyAmount += Time.deltaTime * percentageIncrementPerSeconds;
            if(difficultyAmount > 1f) {
                difficultyAmount = 1f;
            }
        }
    }

    public void Reinitialize() {
        difficultyAmount = 0f;
    }
    #endregion
}
