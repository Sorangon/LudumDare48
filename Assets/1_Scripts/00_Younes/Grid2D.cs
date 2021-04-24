using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    [Header ("Grid Size")]
    public int height;
    public int width;
    Vector3 offset = new Vector3(.5f, .5f, 0);

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
            Gizmos.DrawLine(new Vector3(i, 0, 0) - offset, new Vector3(i, height, 0) - offset);
        }

        for (int j = 0; j <= height; j++)
        {
            Gizmos.DrawLine(new Vector3(0, j, 0) - offset, new Vector3(width, j, 0) - offset);
        }
    }
}
