using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DM_", menuName = "Game/Difficulty Modulator")]
public class DifficultyModulator : ScriptableObject {
    #region Settings
    [MinMaxSlider(0f, 1f)] public Vector2 minDifficultyAmount = new Vector2(0f, 1f);
    #endregion

    #region Current
    private float difficultyAmount = 0f;
    #endregion

    #region Properties
    public float DifficultyAmount => difficultyAmount;
    #endregion
}
