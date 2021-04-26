using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Gameplay/CollectibleSpawner")]
public class CollectibleSpawner : ScriptableObject
{
    [Range (0, 100)] public int spawnChancePercent;
    public GameObject crystalPrefab = null;
    public GameObject heartPrefab = null;
    
    public void CreateCollectible(Transform tilePosition)
	{
        int rng = Random.Range(0, 100);

        if (rng <= spawnChancePercent)
		{
            Instantiate(crystalPrefab, tilePosition.position, Quaternion.identity);
		}
	}
}
