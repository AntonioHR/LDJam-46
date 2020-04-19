using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation {
    [SerializeField]
    private Animator animator;

    private const string Key_Speed = "Speed";
    private const string Key_Jumping = "Jumping";
    private const float Delta_BlendMoveAnimation = 5f;

    private MoveByInput movement;
    private CharacterController charController;

    public PlayerAnimation(MoveByInput movement, CharacterController charController, Animator animator) {
        this.movement = movement;
        this.animator = animator;
        this.charController = charController;
    }

    public void Update() {
        animator.SetFloat(Key_Speed, Mathf.MoveTowards(animator.GetFloat(Key_Speed), movement.DeltaMovement, Delta_BlendMoveAnimation * Time.deltaTime));
    }

    public void OnLeftGround() {
        //Debug.Log("OnLeftGround");
        animator.SetBool(Key_Jumping, true);
    }

    public void OnBecameGrounded() {
       // Debug.Log("OnBecameGrounded");
        animator.SetBool(Key_Jumping, false);
    }
}
