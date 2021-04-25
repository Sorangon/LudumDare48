using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TileSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Grid2D grid2D;
    [SerializeField] DifficultyModulator dm;

    [Header("Parameters")]
    public int chunkHeight;
    public bool fillLines = false;
    [Range(0, 100)] public int fillPercent;
    [Range(0, 80)] public int wallPercent;
    [Range(0, 20)] public int enemyPercent;

    int globalHeight;

    [Button]
    public void GenerateTileChunk()
    {
        LevelSpawner ls = FindObjectOfType<LevelSpawner>();
        GameObject holder = new GameObject();
        holder.transform.SetParent(this.transform);

        UpdateDifficulty();

        globalHeight = ls.currentLine;
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
        for (int i = 0; i < childs; i++)
        {
            if (!Application.isPlaying)
                DestroyImmediate(transform.GetChild(0).gameObject);
            else
                Destroy(transform.GetChild(0).gameObject);
        }
    }

    void UpdateDifficulty()
    {
        //Difficulty update
        //Fill pct++
        //Wall pct++
        //Chunk height ++

        float d = dm.DifficultyAmount; //Between 0 or 1

        //Lower max chunk per level & Lower space Btw chunks
        if (d < .1)
        {
            chunkHeight = 2;
            fillPercent = 50;
            wallPercent = 0;
            enemyPercent = 0;
        }
        else if (d < .2)
        {
            chunkHeight = 2;
            fillPercent = 55;
            wallPercent = 2;
            enemyPercent = 2;
        }
        else if (d < .3)
        {
            chunkHeight = 3;
            fillPercent = 60;
            wallPercent = 5;
            enemyPercent = 2;
        }
        else if (d < .4)
        {
            chunkHeight = 3;
            fillPercent = 65;
            wallPercent = 8;
            enemyPercent = 3;
        }
        else if (d < .5)
        {
            chunkHeight = 3;
            fillPercent = 70;
            wallPercent = 10;
            enemyPercent = 4;

        }
        else if (d < .6)
        {
            chunkHeight = 3;
            fillPercent = 75;
            wallPercent = 10;
            enemyPercent = 5;
        }
        else if (d < .7)
        {
            chunkHeight = 4;
            fillPercent = 75;
            wallPercent = 12;
            enemyPercent = 5;
        }
        else if (d < .8)
        {
            chunkHeight = 4;
            fillPercent = 80;
            wallPercent = 14;
            enemyPercent = 5;
        }

        else if (d < .9)
        {
            chunkHeight = 4;
            fillPercent = 85;
            wallPercent = 17;
            enemyPercent = 6;
        }
        else
        {
            chunkHeight = 5;
            fillPercent = 90;
            wallPercent = 20;
            enemyPercent = 6;
        }
    }
}

