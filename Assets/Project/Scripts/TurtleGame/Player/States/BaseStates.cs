using JammerTools.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleGame.Player
{
    public class PlayerStateMachine : StateMachine<PlayerController, PlayerState>
    {
        public override PlayerState DefaultState => new IdleState();


        public void Update()
        {
            CurrentState.Update();
        }

        public void OnJumpPressed()
        {
            CurrentState.OnJumpPressed();
        }
    }

    public abstract class PlayerState : State<PlayerController, PlayerState>
    {
        public PlayerController player => Context;

        public virtual void Update() {

            player.cameraMover.Update();
            player.horizontalMover.Update();
            player.physicsMover.Update();
        }

        public virtual void OnJumpPressed() { }
    }
}
