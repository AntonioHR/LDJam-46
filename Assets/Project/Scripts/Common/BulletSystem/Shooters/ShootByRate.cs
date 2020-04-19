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



            public float maxHeat = 100;
            public float heatByShot = 10;
            public float fastCoolDown = 10;
            public float fastCooldownRate { get => maxHeat / fastCoolDown; }
            public float slowCooldown = 5;
            public float slowCooldownRate { get => maxHeat / slowCooldown; }
            public float cooldownDelay = .5f;
        }
        public delegate void ShootHandler(Bullet bullet);

        public event ShootHandler Shot;
        public event Action overheatStart;
        public event Action overheatFinished;

        private Settings settings;
        private IShootSpot shootSpot;
        private float interval;
        private float heat;
        private bool isOnOverheat;

        //State
        private Timer cooldownTimer = new Timer();
        private Timer fireRateTimer = new Timer();
        private bool autoFire;
        private float next;

        public bool IsOnOverheat { get => isOnOverheat; set => isOnOverheat = value; }
        public float HeatAlpha { get => heat / settings.maxHeat; }

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
            if (fireRateTimer.ElapsedSeconds > next || !fireRateTimer.IsActive)
            {
                fireRateTimer.Restart();
                next = 0;
            }
        }

        public void DisableAutoFire()
        {
            autoFire = false;
            cooldownTimer.Restart();
        }

        public void TryShootOnce()
        {
            TryShoot();
        }

        public void Update()
        {
            if (autoFire && !IsOnOverheat)
            {
                TryShoot();
            } else if (IsOnOverheat)
            {
                heat -= Time.deltaTime * settings.slowCooldownRate;
                heat = Mathf.Max(0, heat);
                if(heat == 0)
                {
                    IsOnOverheat = false;
                }
            } else
            {
                if (cooldownTimer.ElapsedSeconds > settings.cooldownDelay)
                {
                    heat -= Time.deltaTime * settings.fastCooldownRate;
                    heat = Mathf.Max(0, heat);
                }
            }
        }

        private void TryShoot()
        {
            if (fireRateTimer.ElapsedSeconds >= next)
            {
                var bullet = Bullet.Shoot(settings.bullet, shootSpot.Origin, shootSpot.Direction);
                Shot?.Invoke(bullet);
                next += interval;
                IncreaseHeatByOneShot();
            }
        }

        private void IncreaseHeatByOneShot()
        {
            heat += settings.heatByShot;
            if (heat >= settings.maxHeat)
            {
                heat = settings.maxHeat;
                IsOnOverheat = true;
            }
        }
    }
}
