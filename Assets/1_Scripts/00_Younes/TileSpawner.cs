using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] Grid2D grid2D;
    [SerializeField] Transform tileHolder;

    [Header("Debug")]
    public int globalHeight;

    [Header("Parameters")]
    public int chunkHeight;
    public bool fillLines = false;
    [Range(0, 100)] public int fillPercent;
    [Range(0, 100)] public int wallPercent;

    [Button]
    public void GenerateTileChunk()
    {
        LevelSpawner ls = FindObjectOfType<LevelSpawner>();
       // Transform tileHolder = new GameObject().transform;

        globalHeight= ls.currentLine;

        for (int n = 0; n < chunkHeight; n++)
        {
            for (int i = 0; i < grid2D.width; i++)
            {
                int wallRng = Random.Range(0, 100);

                if (!fillLines)
                {
                    int fillRng = Random.Range(0, 100);

                    if (fillRng < fillPercent)
                    {
                        if (wallRng < wallPercent)
						{
                            CreateTilePrefab(tilePrefab, i, globalHeight + chunkHeight + n);
                        } else
						{
                            CreateTilePrefab(wallPrefab, i, globalHeight + chunkHeight + n);
						}
                    }
                }
                else
                {
                    if (wallRng < wallPercent)
                    {
                        CreateTilePrefab(tilePrefab, i, globalHeight + chunkHeight + n);
                    }
                    else
                    {
                        CreateTilePrefab(wallPrefab, i, globalHeight + chunkHeight + n);
                    }
                }
            }
        }
    }
    public void CreateTilePrefab(GameObject prefab, int x, int y)
	{
        Vector3 pos = new Vector3(x, y, 0);
        GameObject tile = Instantiate(prefab, pos, Quaternion.identity);
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
