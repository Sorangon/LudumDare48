using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public abstract class TweenComponent : MonoBehaviour {
    #region Settings
    public bool playOnAwake = false;
    public bool loop = false;
    public bool forceComplete = true;
    public float duration = 1f;
    #endregion

    #region Currents
    private Tween currentTween = null;
    #endregion

    #region Callbacks
    private void OnEnable() {
        if (playOnAwake) {
            Tween();
        }
    }

    private void OnDisable() {
        currentTween.Complete();
        currentTween.Kill();
        currentTween = null;
    }
    #endregion

    #region Behaviour
    [Button("Simulate", EButtonEnableMode.Playmode)]
    public void Tween() {
        void TriggerTween() {
            currentTween = GetTween();
            if (loop) {
                currentTween.OnComplete(TriggerTween);
            }
        }

        if (forceComplete) {
            if (currentTween != null) {
                currentTween.Complete();
            }
            TriggerTween();
        } else {
            if(currentTween == null) {
                TriggerTween();
            }
        }
    }

    protected abstract Tween GetTween();
    #endregion
}
