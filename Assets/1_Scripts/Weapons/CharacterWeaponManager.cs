using UnityEngine;

public class CharacterWeaponManager : MonoBehaviour {
    #region Settings
    public Transform weaponAnchor = null;
    public Weapon currentWeapon = null;
    #endregion

    #region Callbacks
    public void Trigger() {
        if (!ReferenceEquals(currentWeapon, null)) {
            currentWeapon.Trigger();
        }
    }

    public void Release() {
        if (!ReferenceEquals(currentWeapon, null)) {
            currentWeapon.Release();
        }
    }
    #endregion

    #region Aim
    public void SetAimDir(Vector2 dir) {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        weaponAnchor.transform.eulerAngles = Vector3.forward * angle;
    }
    #endregion
}
