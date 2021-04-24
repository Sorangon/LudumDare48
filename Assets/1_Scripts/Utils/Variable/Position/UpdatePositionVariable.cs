using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePositionVariable : MonoBehaviour {
    public PositionVariable positionVariable = null;

    void Update() {
        positionVariable.position = transform.position;
    }
}
