namespace TurtleGame.Player
{
    public class IdleState : PlayerState
    {

        public override void OnLeftGround()
        {
            ExitTo(new AirborneState());
        }
        public override void OnJumpPressed()
        {

            player.physicsMover.DoDefaultJump();
            ExitTo(new AirborneState());
        }
    }
}