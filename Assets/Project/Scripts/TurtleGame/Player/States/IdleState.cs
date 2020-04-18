namespace TurtleGame.Player
{
    public class IdleState : PlayerState
    {

        public override void OnJumpPressed()
        {
            player.physicsMover.DoDefaultJump();
        }
    }
}