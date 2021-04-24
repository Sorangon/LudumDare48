using UnityEngine;

[CreateAssetMenu(fileName = "newLootObjects", menuName = "Gameplay/Death Behaviours/Player Death", order = 0)]
public class PlayerDeath : DeathBehaviour {
    public delegate void PlayerDeathAction();
    public event PlayerDeathAction onPlayerDies;

    public override void Execute(Health ownerHealthSystem, Object param) {
        Debug.Log("Player is dead");
        onPlayerDies?.Invoke();
        Destroy(ownerHealthSystem.gameObject);
    }
}
