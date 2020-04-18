using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPSCameraMover
{

    [Serializable]
    public class Settings
    {
        public float speed= 10;
        public float minPitch = -45;
        public float maxPitch = 45;
    }

    private Settings settings;
    private Transform pivot;
    private Transform cam;
    private InputAction moveInput;
    private float pitch;

    public float speed => settings.speed;

    public TPSCameraMover(Settings settings, Transform pivot, Transform cam, UnityEngine.InputSystem.InputAction moveInput)
    {
        this.settings = settings;
        this.pivot = pivot;
        this.cam = cam;
        this.moveInput = moveInput;
    }

    public void Update()
    {
        Vector2 delta = moveInput.ReadValue<Vector2>();
        delta *= speed * Time.deltaTime;

        pivot.localRotation *= Quaternion.AngleAxis(delta.x, Vector3.up);

        pitch += -1 * delta.y;
        pitch = Mathf.Clamp(pitch, settings.minPitch, settings.maxPitch);
        cam.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);

    }
}
