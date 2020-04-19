using JammerTools.BulletSystem;
using JammerTools.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TurtleGame.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(TPSShootSpot))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField]
        private Transform xCamRotate;
        [SerializeField]
        private Transform yCamRotate;
        [SerializeField]
        private Transform camShootRef;
        [SerializeField]
        private Animator animator;


        [Header("Movement")]
        [SerializeField]
        private MoveByInput.Settings walkSettings;
        [SerializeField]
        private MoveByPhysics.Settings jumpSettings;
        [SerializeField]
        private TPSCameraMover.Settings cameraSettings;

        [Header("Shooting")]
        [SerializeField]
        private ShootByRate.Settings defaultShotSettings;



        public MoveByInput horizontalMover;
        public MoveByPhysics physicsMover;
        public MoveByPlatforms moveByPlatforms;
        public TPSCameraMover cameraMover;
        public ShootByRate defaultShooter;
        public PlayerAnimation playerAnimation;

        private CharacterController charController;
        private GameControls gameControls;
        private PlatformCheckArea platformCheck;
        private PlayerStateMachine stateMachine;
        private TPSShootSpot shooter;
        private bool wasGrounded;

        public bool IsGrounded { get; private set; }
        public string DebugStateName {
            get
            {
                if (stateMachine == null)
                    return "null";
                return stateMachine.DebugStateName;
            }
        }


        #region Initialization
        private void Start()
        {
            FindComponentDependencies();
            InitControls();
            InitMovements();
            InitShootBehaviours();

            stateMachine = new PlayerStateMachine();
            stateMachine.Begin(this);
        }

        private void InitShootBehaviours()
        {
            defaultShooter = new ShootByRate(defaultShotSettings, shooter);
        }

        private void FindComponentDependencies()
        {
            charController = GetComponent<CharacterController>();
            shooter = GetComponent<TPSShootSpot>();
            platformCheck = GetComponentInChildren<PlatformCheckArea>();
        }

        private void InitControls()
        {
            gameControls = new GameControls();

            gameControls.Ingame.Jump.performed += OnJump;
            gameControls.Ingame.Fire.started += OnFireUp;
            gameControls.Ingame.Fire.canceled += OnFireDown;
            gameControls.Ingame.SuperFire.performed += OnSuperFire;
            gameControls.Enable();
        }

        private void InitMovements()
        {
            horizontalMover = new MoveByInput(walkSettings, charController, gameControls.Ingame.Move);
            physicsMover = new MoveByPhysics(jumpSettings, charController);
            moveByPlatforms = new MoveByPlatforms(charController, platformCheck);
            cameraMover = new TPSCameraMover(cameraSettings, xCamRotate, yCamRotate, gameControls.Ingame.Aim);
            playerAnimation = new PlayerAnimation(horizontalMover, charController, animator);
        }
        #endregion


        public void Update()
        {
            stateMachine.Update();
        }

        public void LateUpdate()
        {
            stateMachine.LateUpdate();
            CheckGround();
        }

        private void CheckGround()
        {
            if (!wasGrounded && 
                (charController.isGrounded
                //|| platformCheck.ObjectsInArea.Any()
                ))
            {
                IsGrounded = true;
                stateMachine.OnBecameGrounded();
            } else if (wasGrounded &&
                (!charController.isGrounded && !platformCheck.ObjectsInArea.Any()))
            {
                IsGrounded = false;
                stateMachine.OnLeftGround();
            }

            wasGrounded = IsGrounded;
        }

        private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            stateMachine.OnJumpPressed();
        }
        private void OnSuperFire(InputAction.CallbackContext obj)
        {
            stateMachine.OnSuperFire();
        }

        private void OnFireUp(InputAction.CallbackContext obj)
        {
            stateMachine.OnFireUp();
        }

        private void OnFireDown(InputAction.CallbackContext obj)
        {
            stateMachine.OnFireDown();
        }

    }
}
