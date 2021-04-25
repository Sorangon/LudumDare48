using UnityEngine;

public class ScoreCollectable : Collectable {
    #region Settings
    [Min(0)] public int points = 500;
    public ScoreManager scoreManager = null;
    #endregion

    #region Collectable Callback
    protected override void OnCollect() {
        scoreManager.AddPoints(points);
        base.OnCollect();
    } 
    #endregion
}
