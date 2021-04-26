using UnityEngine;

public class RotationSpriteAutoFlip : MonoBehaviour {
    public SpriteRenderer targetSprite = null;
    public bool invert = false;

    void Update() {
        targetSprite.flipY = (transform.eulerAngles.z > 90f && transform.eulerAngles.z < 270f);
    }
}
