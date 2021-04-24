using UnityEngine;

public static class Collider2DExtensions {
    public static bool TryGetHealthSystem(this Collider2D col, out Health healthSystem) {
        GameObject rootGo = col.attachedRigidbody != null ? col.attachedRigidbody.gameObject : col.gameObject;
        return rootGo.TryGetComponent(out healthSystem);
    }
}
