using UnityEngine;

public class GameManagerHandler : MonoBehaviour {
    #region Settings
    public GameManager gameManager = null;
    #endregion

    #region Callbacks
    private void Awake() {
        gameManager.Reinitialize() ;
    }

    private void Update() {
        gameManager.Update();
    }

    private void OnDestroy() {
        if (Application.isPlaying) {
            gameManager.Reinitialize();
        }
    }
    #endregion
}
