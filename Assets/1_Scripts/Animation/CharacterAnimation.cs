using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    #region Settings
    public Animator animator = null;
    public CharacterController2D characterController = null;
    #endregion

    #region Currents
    private int isJumpingProp = Animator.StringToHash("IsJumping");
    private int speedProp = Animator.StringToHash("Speed");
    private int jumpProp = Animator.StringToHash("Jump");
    #endregion


    private void Update() {
        float speed = characterController.CurrentSpeed;
        float absSpeed = Mathf.Abs(speed);
        if (absSpeed > 0.1f) {
            transform.localScale = new Vector3(Mathf.Sign(-speed), 1f, 1f);
        }
        animator.SetFloat(speedProp, absSpeed);   
    }

    public void OnJump() {
        animator.SetBool(isJumpingProp, true);
    }

    public void OnLand() {
        animator.SetBool(isJumpingProp, false);
    }
}
