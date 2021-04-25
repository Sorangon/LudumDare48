using UnityEngine;

public class SetFramerate : MonoBehaviour {
    [Range(30, 120)]public int targetFramerate = 60;

    private void Awake() {
        Application.targetFrameRate = targetFramerate;
    }
}
