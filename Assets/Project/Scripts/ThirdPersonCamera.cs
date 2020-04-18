using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private float turnRate = 5;
    [SerializeField]
    float maxY = 75;
    [SerializeField]
    float minY = -90;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce = 5;


    GameControls gameControls;
    private CharacterController charControl;
    float y = 0;

    void Start()
    {
        gameControls = new GameControls();
        gameControls.Enable();
        gameControls.Ingame.Jump.performed += JumpPressed;

        charControl = GetComponent<CharacterController>();
    }

    private void JumpPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //if(charControl.isGrounded)
        //{
        //    charControl. += Vector3.up * jumpForce;
        //}
    }

    void Update()
    {
        UpdateCamera();

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        Vector2 delta = gameControls.Ingame.Move.ReadValue<Vector2>();

        Vector3 move = delta.x * transform.right + delta.y * transform.forward;



        charControl.SimpleMove(move * moveSpeed);
    }

    private void UpdateCamera()
    {
        Vector2 delta = gameControls.Ingame.Aim.ReadValue<Vector2>();
        delta *= turnRate;

        transform.localRotation *= Quaternion.AngleAxis(delta.x, Vector3.up);

        y += -1 * delta.y;
        y = Mathf.Clamp(y, minY, maxY);
        camera.transform.localRotation = Quaternion.AngleAxis(y, Vector3.right);

    }
}
