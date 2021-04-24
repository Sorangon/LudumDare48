using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    [Header ("Grid Size")]
    [SerializeField] int height;
    [SerializeField] int width;

    GameObject[,] tiles;


    void Start()
    {
        tiles = new GameObject[width, height];
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.green;

        for (int i = 0; i <= width; i++)
		{
            Gizmos.DrawLine(new Vector3(i, 0, 0), new Vector3(i, height, 0));
        }

        for (int j = 0; j <= height; j++)
        {
            Gizmos.DrawLine(new Vector3(0, j, 0), new Vector3(width, j, 0));
        }
    }
}
