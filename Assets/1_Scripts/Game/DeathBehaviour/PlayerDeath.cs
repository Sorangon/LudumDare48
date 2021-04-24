using UnityEngine;

[CreateAssetMenu(fileName = "newLootObjects", menuName = "Gameplay/Death Behaviours/Player Death", order = 0)]
public class PlayerDeath : DeathBehaviour {
    #region Datas
    public GameManager gameManager = null;
    #endregion

    #region Events
    public delegate void PlayerDeathAction();
    public event PlayerDeathAction onPlayerDies;
    #endregion

    #region Behaviour
    public override void Execute(Health ownerHealthSystem, Object param) {
        Debug.Log("Player is dead");

        if(gameManager != null) {
            gameManager.EndGame();
        }

        onPlayerDies?.Invoke();
        Destroy(ownerHealthSystem.gameObject);
    } 
    #endregion
}
