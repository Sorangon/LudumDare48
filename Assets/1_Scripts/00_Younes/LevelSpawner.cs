using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class LevelSpawner : MonoBehaviour
{
	#region Fields
	[Header ("References")]
    public Grid2D grid;
    public TileSpawner ts;
    public GameObject nextLevelThresholdPrefab;

    [Header("Spawner Attributes")]
    [SerializeField] int spawnerHeight = 0;

    [Header ("Basic Generation Rules")]
    public int currentLine = 0;
    public int maxChunks = 10;
    public int distanceBetweenChunks = 20;
    private int maxLines;

    public bool firstChunks = true;

	#endregion
	void Start()
    {
        spawnerHeight = 0;
        firstChunks = true;
        ClearLevel();
        GenerateLevel();
    }

    [Button] 
    public void GenerateLevel()
	{
        //Init
        transform.position = new Vector3(0, 0, 0);
        maxLines = maxChunks * distanceBetweenChunks;
        ClearLevel();
        currentLine = 0;

        //Generate all chunks
        for (int lineIndex = 0; lineIndex <= maxLines; lineIndex+= distanceBetweenChunks)
		{
            currentLine = spawnerHeight + lineIndex;
            ts.GenerateTileChunk();
		}

        //Updating level offset to be centered
        Vector3 pos = new Vector3(-grid.width / 2, 0, 0);
        transform.position = pos;

        //Threshold for triggering next Level Generation
        Vector3 thresholdPos = new Vector3(0, (currentLine +  1 * distanceBetweenChunks) * -1, 0) ; //Tweak this to get correct value
        GameObject nextLevelThreshold = Instantiate(nextLevelThresholdPrefab, thresholdPos, Quaternion.identity);
        nextLevelThreshold.name = "Next Level Threshold Prefab";
        nextLevelThreshold.transform.SetParent(this.transform);

        //Next Spawner height
        spawnerHeight += maxLines;
	}
    
    [Button]
    private void ClearLevel()
    {
        ts.ClearTileHolder();
    }
}
