using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TurtleGame.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField]
        private Transform xCamRotate;
        [SerializeField]
        private Transform yCamRotate;
        [SerializeField]
        private Transform camShootRef;

        [Header("Movement")]
        [SerializeField]
        private MoveByInput.Settings walkSettings;
        [SerializeField]
        private MoveByPhysics.Settings jumpSettings;
        [SerializeField]
        private TPSCameraMover.Settings cameraSettings;


        private CharacterController charController;
        private GameControls gameControls;

        public MoveByInput horizontalMover;
        public MoveByPhysics physicsMover;
        public TPSCameraMover cameraMover;

        private PlayerStateMachine stateMachine;


        #region Initialization
        private void Start()
        {
            FindComponentDependencies();
            InitMovements();

            stateMachine = new PlayerStateMachine();
            stateMachine.Begin(this);
        }
        private void FindComponentDependencies()
        {
            charController = GetComponent<CharacterController>();
            gameControls = new GameControls();

            gameControls.Ingame.Jump.performed += OnJump;
            gameControls.Enable();
        }
        private void InitMovements()
        {
            horizontalMover = new MoveByInput(walkSettings, charController, gameControls.Ingame.Move);
            physicsMover = new MoveByPhysics(jumpSettings, charController);
            cameraMover = new TPSCameraMover(cameraSettings, xCamRotate, yCamRotate, gameControls.Ingame.Aim);
        }
        #endregion


        public void Update()
        {
            stateMachine.Update();
        }

        private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            stateMachine.OnJumpPressed();
        }

    }
}
