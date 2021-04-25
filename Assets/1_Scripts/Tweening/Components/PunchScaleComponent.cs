using DG.Tweening;
using UnityEngine;

public class PunchScaleComponent : TweenComponent {
    #region Settings
    [Header("Settings")]
    public Vector3 punch = Vector3.one;
    public int vibrato = 10;
    public float elasticity = 1f;
    #endregion

    protected override Tween GetTween() {
        return transform.DOPunchScale(punch, duration, vibrato, elasticity);
    }
}
