using UnityEngine;

namespace TurtleGame.Player
{
    public class JumpState : PlayerState
    {
        private Vector3 move;

        protected override void Begin()
        {
            move = player.horizontalMover.CurrentMove;

            player.physicsMover.DoDefaultJump();
        }

        public override void Update()
        {
            player.cameraMover.Update();
            player.horizontalMover.UpdateByInput();
            player.physicsMover.Update();
        }

        public override void OnBecameGrounded()
        {
            ExitTo(new IdleState());
        }
    }
}