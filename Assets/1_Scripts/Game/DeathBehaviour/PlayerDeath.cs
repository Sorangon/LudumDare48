using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLootObjects", menuName = "Gameplay/Death Behaviours/Player Death", order = 0)]
public class PlayerDeath : DeathBehaviour {
    public override void Execute(Health ownerHealthSystem, Object param) {
        Debug.Log("Player is dead");
        Destroy(ownerHealthSystem.gameObject);
    }
}
