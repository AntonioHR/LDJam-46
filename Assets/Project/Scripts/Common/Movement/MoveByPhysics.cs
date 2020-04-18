using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByPhysics
{

    [Serializable]
    public class Settings
    {
        public float defaultJump= 10;
        public float gravity = 20;
    }

    private Settings settings;

    private CharacterController charController;


    private Vector3 ySpeed;


    //helpers
    private Transform transform => charController.transform;

    public MoveByPhysics(Settings settings, CharacterController target)
    {
        this.settings = settings;
        this.charController = target;
    }


    public void DoDefaultJump()
    {
        DoJump(settings.defaultJump);
    }
    public void DoJump(float jump)
    {
        ySpeed = Vector3.up * jump;
    }

    public void Update()
    {
        if (charController.isGrounded)
        {
            ySpeed = Vector3.zero;
            return;
        }
        ySpeed += Time.deltaTime * settings.gravity * Vector3.down;

        charController.Move(ySpeed * Time.deltaTime);
    }
}
