using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour {
    #region Settings
    [Foldout("Events")]
    [SerializeField] private UnityEvent onCollect = new UnityEvent();
    #endregion

    #region Collectable Callbacks
    protected virtual void OnCollect(CharacterController2D character) {
        onCollect?.Invoke();
        Destroy(gameObject);
    }
    #endregion

    #region Physic Callbacks
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponentOnRoot(out CharacterController2D chara)) {
            OnCollect(chara);
        }
    }
    #endregion
}
