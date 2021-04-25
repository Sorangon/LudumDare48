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

			//Destroy old level


			//Destroy this
			Destroy(this.gameObject);
		}
	}
}
