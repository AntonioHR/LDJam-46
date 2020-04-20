namespace TurtleGame.Player
{
    public class IdleState : PlayerState
    {

        protected override void Begin()
        {
            player.moveByPlatforms.Reset();
        }
        public override void OnLeftGround()
        {
            //player.playerAnimation.OnStartFalling();
            ExitTo(new AirborneState());
        }

        public override void LateUpdate()
        {
            player.moveByPlatforms.LateUpdate();
        }
        public override void OnJumpPressed()
        {
            player.jumpEvent.Invoke();
            player.playerAnimation.OnLeftGround();
            player.physicsMover.DoDefaultJump();
            ExitTo(new AirborneState());
        }
    }
}