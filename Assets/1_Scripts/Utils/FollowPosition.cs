using UnityEngine;

public class FollowPosition : MonoBehaviour {
    public PositionVariable targetPos = null;

    public bool lockX = false;
    public bool lockY = false;

    private void LateUpdate() {
        Vector2 pos = new Vector2(lockX ? transform.position.x : targetPos.position.x,
            lockY ? transform.position.y : targetPos.position.y);
        transform.position = pos;
    }
}
