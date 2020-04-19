using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation {
    [SerializeField]
    private Animator animator;

    private const string Key_AxisX = "AxisX";
    private const string Key_AxisY = "AxisY";
    private const string Key_Jumping = "Jumping";
    private const string Key_Falling = "Falling";
    private const string Key_Shooting = "Shooting";
    private const float Delta_BlendMoveAnimation = 5f;

    private MoveByInput movement;
    private CharacterController charController;

    public PlayerAnimation(MoveByInput movement, CharacterController charController, Animator animator) {
        this.movement = movement;
        this.animator = animator;
        this.charController = charController;
    }

    public void Update() {
        animator.SetFloat(Key_AxisX, movement.InputAxis.x);
        animator.SetFloat(Key_AxisY, movement.InputAxis.y);
    }

    public void OnStartFalling () {
        animator.SetBool(Key_Falling, true);
    }

    public void OnLeftGround() {
        animator.SetBool(Key_Jumping, true);
    }

    public void OnBecameGrounded() {
        animator.SetBool(Key_Jumping, false);
        animator.SetBool(Key_Falling, false);
    }

    public void ToggleShooting(bool isShooting) {
        animator.SetBool(Key_Shooting, isShooting);
    }
}
