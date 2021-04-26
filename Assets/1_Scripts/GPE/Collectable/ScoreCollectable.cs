using UnityEngine;

public class ScoreCollectable : Collectable {
    #region Settings
    [Min(0)] public int points = 500;
    public ScoreManager scoreManager = null;
    #endregion

    #region Collectable Callback
    protected override void OnCollect(CharacterController2D character) {
        scoreManager.AddPoints(points);
        base.OnCollect(character);
    } 
    #endregion
}
