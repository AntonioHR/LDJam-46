namespace TurtleGame.Player
{
    public class IdleState : PlayerState
    {
        public override void OnLeftGround()
        {
            //player.playerAnimation.OnStartFalling();
            ExitTo(new AirborneState());
        }
        public override void OnJumpPressed()
        {
            player.playerAnimation.OnLeftGround();
            player.physicsMover.DoDefaultJump();
            ExitTo(new AirborneState());
        }
    }
}