using UnityEngine;

public class FollowPosition : MonoBehaviour {
    public PositionVariable targetPos = null;

    private void LateUpdate() {
        transform.position = targetPos.position;
    }
}
