using JammerTools.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using TurtleGame.Player;
using UnityEngine;

namespace JammerTools.BulletSystem
{
    public class ShootByRate 
    {
        [Serializable]
        public class Settings
        {
            public float rate = 2f;
            public Bullet bullet;
        }
        public delegate void ShootHandler(Bullet bullet);

        public event ShootHandler Shot;

        private Settings settings;
        private IShootSpot shootSpot;
        private float interval;

        //State
        private Timer timer = new Timer();
        private bool autoFire;
        private float next;

        public ShootByRate(Settings settings, IShootSpot shootSpot)
        {
            this.settings = settings;
            this.shootSpot = shootSpot;
            interval = 1 / settings.rate;
        }

        public void EnableAutoFire()
        {
            if (autoFire)
                return;

            autoFire = true;
            if (timer.ElapsedSeconds > next || !timer.IsActive)
            {
                timer.Restart();
                next = 0;
            }
        }

        public void DisableAutoFire()
        {
            autoFire = false;
        }

        public void TryShootOnce()
        {
            TryShoot();
        }

        public void Update()
        {
            if (!autoFire)
                return;
            TryShoot();
        }

        private void TryShoot()
        {
            if (timer.ElapsedSeconds >= next)
            {
                var bullet = Bullet.Shoot(settings.bullet, shootSpot.Origin, shootSpot.Direction);
                Shot?.Invoke(bullet);
                next += interval;
            }
        }
    }
}
