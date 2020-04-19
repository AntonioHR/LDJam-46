using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace JammerTools.Movement
{
    public class MoveByInput
    {

        [Serializable]
        public class Settings
        {
            public Vector3 xAxis = Vector3.right;
            public Vector3 yAxis = Vector3.forward;
            public float moveSpeed = 10;
        }

        private Settings settings;

        private CharacterController target;
        private InputAction moveInput;
        private Vector2 input;


        //helpers
        private Transform transform => target.transform;
        public Vector3 xAxis => settings.xAxis;
        public Vector3 yAxis => settings.yAxis;
        public float moveSpeed => settings.moveSpeed;

        public Vector2 InputAxis { get { return input; } }

        public MoveByInput(Settings settings, CharacterController target, UnityEngine.InputSystem.InputAction moveInput)
        {
            this.settings = settings;
            this.target = target;
            this.moveInput = moveInput;
        }

        public void UpdateByInput()
        {
            target.Move(CurrentMove * moveSpeed * Time.deltaTime);
        }
        public void UpdateByVel(Vector3 vel)
        {
            target.Move(vel * moveSpeed * Time.deltaTime);
        }
        public Vector3 CurrentMove
        {
            get
            {
                input = moveInput.ReadValue<Vector2>();

                Vector3 move = input.x * transform.TransformDirection(xAxis)
                        + input.y * transform.TransformDirection(yAxis);
                return move;
            }
        }
    }
}