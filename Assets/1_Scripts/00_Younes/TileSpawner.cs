using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] Grid2D grid2D;
    [SerializeField] Transform tileHolder;

    [Header("Debug")]
    public int globalHeight;
    public int localHeight;

    [Header("Parameters")]
    public int chunkHeight;
    public bool fillLines = false;
    [Range(0, 100)] public int fillPercent;

    [Button]
    public void GenerateTileChunk()
    {
        //ClearTileHolder();
        LevelSpawner ls = FindObjectOfType<LevelSpawner>();

        globalHeight= ls.currentLine;
        print("Current Line: " + globalHeight);
        //localHeight = 0;


        for (int n = 0; n < chunkHeight; n++)
        {
            for (int i = 0; i < grid2D.width; i++)
            {
                if (!fillLines)
                {
                    int rng = Random.Range(0, 100);

                    if (rng < fillPercent)
                    {
                        CreateTilePrefab(i, globalHeight + chunkHeight + n);
                    }
                }
                else
                {
                    CreateTilePrefab(i, globalHeight + chunkHeight + n);
                }
            }
        }
    }

    public void CreateTilePrefab(int x, int y)
	{
        Vector3 pos = new Vector3(x, y, 0);
        GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
        tile.transform.SetParent(tileHolder);
    }

    [Button]
    public void ClearTileHolder()
	{
        int childs = tileHolder.childCount;
        for (int i = 0; i < childs; i++)
		{
            if (Application.isEditor)
                DestroyImmediate(tileHolder.GetChild(0).gameObject);
            else
                Destroy(tileHolder.GetChild(0).gameObject);

        }
    }
}
