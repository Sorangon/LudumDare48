using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnThresholdTrigger : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.layer == 6)
		{
			//Spawn new Level
			LevelSpawner ls = FindObjectOfType<LevelSpawner>();
			ls.GenerateLevel();

			if (!ls.firstChunks)
			{
				//Destroy old chunks
				Transform _t = ls.transform;

				for (int i = 0; i <= ls.maxChunks - 1; i++)
				{
					Destroy(_t.GetChild(i).gameObject);
				}
			}

			if (ls.firstChunks)
			{
				ls.firstChunks = false;
			}

			//Destroy this
			Destroy(this.gameObject);
		}
	}
}
