﻿using JammerTools.StateMachines;
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

        public void OnSuperFire()
        {
            CurrentState.OnSuperFire();
        }

        public void OnFireUp()
        {
            CurrentState.OnFireUp();
        }

        public void OnFireDown()
        {
            CurrentState.OnFireDown();
        }

        public void OnBecameGrounded()
        {
            CurrentState.OnBecameGrounded();
        }

        public void OnLeftGround()
        {
            CurrentState.OnLeftGround();
        }
    }

    public abstract class PlayerState : State<PlayerController, PlayerState>
    {
        public PlayerController player => Context;

        public virtual void Update() {

            player.cameraMover.Update();
            player.horizontalMover.UpdateByInput();
            player.physicsMover.Update();
            player.defaultShooter.Update();
        }

        public virtual void OnJumpPressed() { }
        public virtual void OnFireUp()
        {
            player.defaultShooter.EnableAutoFire();
        }
        public virtual void OnFireDown()
        {
            player.defaultShooter.DisableAutoFire();
        }
        public virtual void OnSuperFire() { }

        public virtual void OnBecameGrounded() { }
        public virtual void OnLeftGround() { }

    }
}
