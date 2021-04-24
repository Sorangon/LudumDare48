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

    [Header ("Basic Generation Rules")]
    public int currentLine = 0;
    public int maxLines = 500;
    public int distanceBetweenChunks = 20;

	#endregion
	void Start()
    {
        GenerateLevel();
    }

    [Button] 
    private void GenerateLevel()
	{
        ClearLevel();
        currentLine = 0;

        for (int lineIndex = 0; lineIndex <= maxLines; lineIndex+= distanceBetweenChunks)
		{
            currentLine = lineIndex;
            print("Current line = " + lineIndex);
            ts.GenerateTileChunk();
		}
	}
    
    [Button]
    private void ClearLevel()
    {
#if false
        int childs = this.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            if (Application.isEditor)
                DestroyImmediate(this.transform.GetChild(0).gameObject);
            else
                Destroy(this.transform.GetChild(0).gameObject);

        }
#endif

        ts.ClearTileHolder();
    }
}
