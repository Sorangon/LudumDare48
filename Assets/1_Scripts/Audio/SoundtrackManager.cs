using System.Threading.Tasks;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour {
    #region Settings
    [Header("Soundtracks")]
    public AudioClip hubSoundtrack = null;
    public AudioClip startGameJingle = null;
    public AudioClip gameSoundtrack = null;
    public AudioClip gameOverSoundtrack = null;

    [Header("References")]
    public GameManager gameManager = null;
    public AudioSource source = null;
    #endregion

    #region Currents
    private bool isGameOver = false;
    #endregion

    #region Callbacks
    private void OnEnable() {
        gameManager.onEndGame += OnEndGame;
        gameManager.onStartGame += OnStartGame;
        gameManager.onResetGameState += OnResetGameState;

        OnResetGameState();
    }


    private void OnDisable() {
        gameManager.onEndGame -= OnEndGame;
        gameManager.onStartGame -= OnStartGame;
        gameManager.onResetGameState -= OnResetGameState;
    }
    #endregion


    #region Events
    private void OnEndGame() {
        PlayClip(gameOverSoundtrack);
        isGameOver = true;
    }

    private async void OnStartGame() {
        PlayClip(startGameJingle);

        await Task.Delay(Mathf.RoundToInt(startGameJingle.length * 1000f));

        if (!isGameOver) {
            PlayClip(gameSoundtrack);
        }
    }

    private void OnResetGameState() {
        PlayClip(hubSoundtrack);
        isGameOver = false;
    }

    private void PlayClip(AudioClip clip) {
        source.clip = clip;
        source.Play();
    }
    #endregion
}
