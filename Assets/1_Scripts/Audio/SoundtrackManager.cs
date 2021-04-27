using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

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
    private IEnumerator startGameCoroutine = null;
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
        if (startGameCoroutine != null) {
            StopCoroutine(startGameCoroutine);
        }
    }

    private void OnStartGame() {
        isGameOver = false;
        startGameCoroutine = OnStartGameCoroutine();
        StartCoroutine(startGameCoroutine);
    }

    private IEnumerator OnStartGameCoroutine() {
        PlayClip(startGameJingle);
        yield return new WaitForSecondsRealtime(startGameJingle.length);
        if (!isGameOver) {
            PlayClip(gameSoundtrack);
        }
        yield break;
    }

    private void OnResetGameState() {
        PlayClip(hubSoundtrack);
    }

    private void PlayClip(AudioClip clip) {
        source.clip = clip;
        source.Play();
    }
    #endregion
}
