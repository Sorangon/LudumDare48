using CoreDev.Effects;
using UnityEngine;

public class PlayScaledFeedback : MonoBehaviour {
    public float scaleMultiplier = 1f;
    public FeedbackAsset feedback = null;

    public void Play(float scale) {
        transform.localScale = Vector3.one * scale * scaleMultiplier;
        feedback.Play(transform);
    }
}
