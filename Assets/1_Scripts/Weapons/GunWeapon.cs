using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class GunWeapon : Weapon {
    #region Settings

    [Header("Settings")]
    public float shootRate = 0.2f;
    public float spead = 10f;
    [Min(1)] public int bullets = 1;

    [Header("References")]
    public Projectile projectile = null;
    public Transform muzzlePos = null;

    [Foldout("Events")]
    [SerializeField] private UnityEvent onShoot = new UnityEvent();
    #endregion

    #region Currents
    private float coolDown = 0f;
    private bool shooting = false;
    #endregion

    #region Monobehaviour Callbacks
    private void Update() {
        if(coolDown > 0f) {
            coolDown -= Time.deltaTime;
        }   

        if(shooting && coolDown <= 0f) {
            Shoot();
            coolDown = shootRate;
        }
    }
    #endregion

    #region Weapon Callbacks
    public override void Trigger() {
        shooting = true;
    }

    public override void Release() {
        shooting = false;
    }
    #endregion

    #region Attack
    private void Shoot() {
        for (int i = 0; i < bullets; i++) {
            Quaternion randomRot = Quaternion.AngleAxis(Random.Range(spead * -0.5f, spead * 0.5f), Vector3.forward);
            Instantiate(projectile, muzzlePos.position, muzzlePos.rotation * randomRot);
        }
        onShoot?.Invoke();
    }
    #endregion
}
