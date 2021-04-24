using UnityEngine;

public class GunWeapon : Weapon {
    #region Settings

    [Header("Settings")]
    public float shootRate = 0.2f;

    [Header("References")]
    public Projectile projectile = null;
    public Transform muzzlePos = null;
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
        Instantiate(projectile, muzzlePos.position, muzzlePos.rotation); 
    }
    #endregion
}
