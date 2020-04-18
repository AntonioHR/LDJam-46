namespace TurtleGame.Player
{
    public class ImpulseState : PlayerState
    {

        public override void Update()
        {
            player.cameraMover.Update();
            player.horizontalMover.UpdateByInput();
            player.physicsMover.Update();
        }
    }
}