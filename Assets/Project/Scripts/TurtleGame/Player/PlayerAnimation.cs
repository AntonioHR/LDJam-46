using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation
{
    [SerializeField]
    private Animator animator;

    private const string Key_Speed = "Speed";

    private MoveByInput movement;

    public PlayerAnimation (MoveByInput movement, Animator animator) {
        this.movement = movement;
        this.animator = animator;
    }

    public void Update () {
        animator.SetFloat(Key_Speed, movement.DeltaMovement);
    }
}
