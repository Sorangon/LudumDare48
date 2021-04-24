using UnityEngine;

public class LifeSpan : MonoBehaviour {
    [SerializeField] private float duration = 3f;

    private void Update() {
        duration -= Time.deltaTime;
        if(duration <= 0f) {
            Destroy(gameObject);
        }
    }
}
