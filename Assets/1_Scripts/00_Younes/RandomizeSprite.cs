using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSprite : MonoBehaviour
{
    public Sprite[] sprites;

    void Start()
    {
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

}
