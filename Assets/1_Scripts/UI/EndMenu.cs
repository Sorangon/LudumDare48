using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using SorangonToolset.EnhancedSceneManager;

public class EndMenu : MonoBehaviour {
    #region Settings
    public GameManager gameManager;
    public SceneManager sceneManager;

    [Header("UI")]
    public float fadeDuration = 0.5f;
    public CanvasGroup loadingPanel = null;

    [Space(6f)]
    public GameObject endMenuPanel = null;
    public float endMenuDisplayDelay = 1f;
    #endregion

    #region Currents
    private bool isDisplayingMenu = false;
    #endregion

    #region Callback
    private void OnEnable() {
        isDisplayingMenu = false;
        endMenuPanel.SetActive(false);
        gameManager.onEndGame += OnEndGame;
    }

    private void OnDisable() {
        gameManager.onEndGame -= OnEndGame;     
    }
    #endregion

    #region Input Callbacks
    public void OnContinue(InputAction.CallbackContext callbackContext) {
        if (isDisplayingMenu) {
            HideEndMenu();
            StartCoroutine(Reload());

        }
    }

    public void OnQuit(InputAction.CallbackContext callbackContext) {
        if (isDisplayingMenu) {
            gameManager.QuitGame();
        }
    }
    #endregion

    #region Display
    private IEnumerator DisplayEndMenuCoroutine() {
        yield return new WaitForSeconds(endMenuDisplayDelay);
        endMenuPanel.SetActive(true);
        isDisplayingMenu = true;
    }

    private void HideEndMenu() {
        endMenuPanel.SetActive(false);
        isDisplayingMenu = false;
    }

    private IEnumerator Reload() {
        loadingPanel.DOFade(1f, fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
        sceneManager.ReloadGameScene();
        EnhancedSceneManager.onSceneAllLoaded += OnLoadingCompleted;
    }
    #endregion

    #region Events
    private void OnEndGame() {
        StartCoroutine(DisplayEndMenuCoroutine());
    }

    private void OnLoadingCompleted() {
        EnhancedSceneManager.onSceneAllLoaded -= OnLoadingCompleted;
        loadingPanel.DOFade(0f, fadeDuration);
    }
    #endregion
}
