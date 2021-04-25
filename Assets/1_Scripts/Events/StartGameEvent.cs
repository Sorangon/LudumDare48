using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartGameEvent : MonoBehaviour {
    #region Settings
    public GameManager gameManager = null;
    public UnityEvent onStartGame = new UnityEvent();
    #endregion

    #region Callbacks
    private void OnEnable() {
        gameManager.onStartGame += OnStartGame;
    }

    private void OnDisable() {
        gameManager.onStartGame -= OnStartGame;
    }

    private void OnStartGame() {
        onStartGame?.Invoke();
    }
    #endregion

}
