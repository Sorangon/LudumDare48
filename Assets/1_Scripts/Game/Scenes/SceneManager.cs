using SorangonToolset.EnhancedSceneManager;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneManager", menuName = "Game/Scene Manager")]
public class SceneManager : ScriptableObject {
    #region Datas
    public SceneBundle mainGameSceneBundle = null;
    #endregion

    #region Manage
    public void ReloadGameScene() {
        mainGameSceneBundle.LoadAsync();
    }
    #endregion
}
