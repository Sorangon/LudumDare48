using DG.Tweening;
using UnityEngine;

public class ShakeComponent : TweenComponent {
    [SerializeField, Min(0f)] private float strength = 1f;
    [SerializeField, Min(0f)] private int vibrato = 10;
    [SerializeField, Min(0f)] private float randomness = 90;
    [SerializeField] private bool snapping = false;
    [SerializeField] private bool fadeOut = true;

    protected override Tween GetTween() {
        return transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
    }
}
