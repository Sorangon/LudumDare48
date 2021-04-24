using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class LevelSpawner : MonoBehaviour
{
    [SerializeField] Grid2D grid;
    //Maybe add different TileSpawner with different parameters / tiles prefabs for scaling difficulty
    [SerializeField] TileSpawner ts;

    [Header ("Basic Generation Rules")]
    public int currentLine = 0;
    public int maxLines = 500;
    public int chunkDistance = 20;

    void Start()
    {
        grid = GetComponent<Grid2D>();
        ts = GetComponent<TileSpawner>();
        currentLine = 0;
    }

    [Button] 
    private void GenerateLevel()
	{
        ClearLevel();
        currentLine = 0;

        for (int i = currentLine; i <= maxLines; i+= chunkDistance)
		{
            ts.GenerateTileChunk();
            print("Calling TS");
            currentLine += chunkDistance;
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
