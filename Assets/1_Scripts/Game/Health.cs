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
    [SerializeField] private UnityEvent onHeal = new UnityEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onTakeDamages = new UnityEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onRecover = new UnityEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onEndRecover = new UnityEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onAddMaxHealth = new UnityEvent();
    [Foldout("Events")]
    [SerializeField] private UnityEvent onDie = new UnityEvent();
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

        onHeal?.Invoke();
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

        onTakeDamages?.Invoke();
    }

    public void AddMaxHealth(int amount, float healthPercentageToAdd = 0f) {
        maxHealth += amount;

        if (healthPercentageToAdd > 0) {
            currentHealth += Mathf.CeilToInt(amount * healthPercentageToAdd);
        }

        onAddMaxHealth?.Invoke();
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
