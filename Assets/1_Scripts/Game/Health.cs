using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using CoreDev.Utility;

/// <summary>
/// Base health system for game objects
/// </summary>
public class Health : MonoBehaviour {
    #region Settings
    [SerializeField, Min(0)] private int maxHealth = 100;
    [SerializeField, Min(0f)] private float recoveryTime = 0f;
    public bool invicible = false;

    [Header("Death")]
    [SerializeField] private DeathBehaviour deathBehaviour = null;
    [SerializeField] private Object deathBehaviourParameter = null;

    [Foldout("Events")]
    [SerializeField] private IntEvent onInitHealth = new IntEvent();
    [Foldout("Events")]
    [SerializeField] private IntEvent onInitMaxHealth = new IntEvent();
    [Foldout("Events")]
    [SerializeField] private IntEvent onHeal = new IntEvent();
    [Foldout("Events")]
    [SerializeField] private IntEvent onTakeDamages = new IntEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onRecover = new UnityEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onEndRecover = new UnityEvent();
    [Foldout("Events")]
    [SerializeField] private IntEvent onAddMaxHealth = new IntEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onDie = new UnityEvent();
    #endregion

    #region Classes
    [System.Serializable] public class IntEvent : UnityEvent<int> { }
    #endregion

    #region Currents
    [ShowNonSerializedField] private int currentHealth = 100;
    private Timer recoveryTimer = null;
    #endregion

    #region Properties
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public float CurrentHealthRatio => (float)currentHealth / (float)maxHealth;
    public bool IsRecovering => recoveryTimer != null && recoveryTimer.isPlaying;
    #endregion

    #region Callbacks
    private void Start() {
        currentHealth = maxHealth;
        recoveryTimer = new Timer(recoveryTime, () => onEndRecover?.Invoke());
        onInitHealth?.Invoke(currentHealth);
        onInitMaxHealth?.Invoke(maxHealth);
    }
    #endregion

    #region Update Health
    public void Heal(int amount) {
        if (amount < 0) {
            return;
        }

        currentHealth += amount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        onHeal?.Invoke(currentHealth);
    }

    public void InflictDamages(int amount) {
        if (amount < 0 || invicible || IsRecovering) {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0) {
            Die();
        }

        if(recoveryTime > 0f) {
            if (recoveryTimer.isPlaying) {
                recoveryTimer.Cancel();
            }
            recoveryTimer.Play();
            onRecover?.Invoke();
        }

        onTakeDamages?.Invoke(currentHealth);
    }

    public void AddMaxHealth(int amount) {
        maxHealth += amount;
        onAddMaxHealth?.Invoke(maxHealth);
    }
    #endregion

    #region Die
    public void Die() {
        onDie?.Invoke();
        if (deathBehaviour != null) {
            deathBehaviour.Execute(this, deathBehaviourParameter);
        } else {
            Destroy(gameObject);
        }
    }
    #endregion
}
