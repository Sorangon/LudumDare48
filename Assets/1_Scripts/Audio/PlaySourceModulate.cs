using NaughtyAttributes;
using UnityEngine;

public class PlaySourceModulate : MonoBehaviour {
    #region Settings
    [Min(0f)]public Vector2 pitchRange = Vector2.one;
    [MinMaxSlider(0f, 1f)] public Vector2 volumeRange = Vector2.one;

    [Header("References")]
    [SerializeField] private AudioSource source = null;
    #endregion

    #region Play
    public void Play() {
        source.pitch = Random.Range(pitchRange.x, pitchRange.y);
        source.volume = Random.Range(volumeRange.x, volumeRange.y);
        source.Play();
    }
    #endregion
}
