using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallsBehavior : MonoBehaviour
{
	#region Fields
	[SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] PositionVariable playerPos;
    [SerializeField] DifficultyModulator dm;

    public bool areWallsMoving = false;

    [Header("Bounds")]
    public float startXLeft;
    public float endXLeft;
    [Space]
    public float startXRight;
    public float endXRight;
	#endregion

	void Start()
    {
        leftWall.transform.position = new Vector3(startXLeft, playerPos.position.y, 0);
        rightWall.transform.position = new Vector3(startXRight, playerPos.position.y, 0);

        StartCoroutine(UpdateWalls());
    }

    IEnumerator UpdateWalls()
	{
        while (dm.DifficultyAmount != 1)
		{
            Vector3 targetPosLeft = new Vector3(endXLeft, leftWall.transform.position.y, 0);
            Vector3 targetPosRight = new Vector3(endXRight, rightWall.transform.position.y, 0);

            if (areWallsMoving)
			{
                leftWall.transform.position = Vector3.Lerp(leftWall.transform.position, targetPosLeft, dm.DifficultyAmount);
                rightWall.transform.position = Vector3.Lerp(rightWall.transform.position, targetPosRight, dm.DifficultyAmount);
			}

            leftWall.transform.position = new Vector3(leftWall.transform.position.x, playerPos.position.y, 0);
            rightWall.transform.position = new Vector3(rightWall.transform.position.x, playerPos.position.y, 0);

            yield return new WaitForSeconds (.5f);
        }

        yield return null;

    }
}
