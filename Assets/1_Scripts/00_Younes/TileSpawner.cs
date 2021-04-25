using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TileSpawner : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] Grid2D grid2D;

    [Header("Parameters")]
    public int chunkHeight;
    public bool fillLines = false;
    [Range(0, 100)] public int fillPercent;
    [Range(0, 80)] public int wallPercent;
    int globalHeight;

    [Button]
    public void GenerateTileChunk()
    {
        LevelSpawner ls = FindObjectOfType<LevelSpawner>();
        GameObject holder = new GameObject();
        holder.transform.SetParent(this.transform);

        globalHeight= ls.currentLine;
        holder.name = "Chunk " + (globalHeight / ls.distanceBetweenChunks);

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
                        if (wallRng > wallPercent)
						{
                            CreateTilePrefab(tilePrefab, i, globalHeight + chunkHeight + n, holder.transform);
                        } else
						{
                            CreateTilePrefab(wallPrefab, i, globalHeight + chunkHeight + n, holder.transform);
						}
                    }
                }
                else
                {
                    if (wallRng > wallPercent)
                    {
                        CreateTilePrefab(tilePrefab, i, globalHeight + chunkHeight + n, holder.transform);
                    }
                    else
                    {
                        CreateTilePrefab(wallPrefab, i, globalHeight + chunkHeight + n, holder.transform);
                    }
                }
            }
        }
    }
    public void CreateTilePrefab(GameObject prefab, int x, int y, Transform _parent)
	{
        Vector3 pos = new Vector3(x, y * -1, 0);
        GameObject tile = Instantiate(prefab, pos, Quaternion.identity);
        tile.transform.SetParent(_parent);
    }

    [Button]
    public void ClearTileHolder()
	{
        int childs = transform.childCount;
        print("Childs to destroy : " + childs);
        for (int i = 0; i < childs; i++)
		{
            if (!Application.isPlaying)
                DestroyImmediate(transform.GetChild(0).gameObject);
            else
                Destroy(transform.GetChild(0).gameObject);
        }
    }
}
