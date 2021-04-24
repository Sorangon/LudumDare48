using UnityEngine;

public class UpdatePositionVariable : MonoBehaviour {
    public PositionVariable positionVariable = null;

    void Update() {
        positionVariable.position = transform.position;
    }
}
