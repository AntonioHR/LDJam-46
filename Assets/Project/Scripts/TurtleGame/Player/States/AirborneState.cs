using UnityEngine;

namespace TurtleGame.Player
{
    public class AirborneState : PlayerState
    {
        protected override void Begin()
        {
        }

        public override void Update()
        {
            player.cameraMover.Update();
            player.horizontalMover.UpdateByInput();
            player.physicsMover.Update();
            player.defaultShooter.Update();
        }

        public override void OnBecameGrounded()
        {
            ExitTo(new IdleState());
        }
    }
}