using System;
using DG.Tweening;
using JammerTools.Common;
using JammerTools.Common.Interactables;
using UnityEngine;

namespace JammerTools.BulletSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : ObjectTrigger3D<IHittable>
    {
        private Rigidbody rb;
        [SerializeField]
        private float speed;
        [SerializeField]
        private bool killOnHit;
        [SerializeField]
        private float autoKillTimer = 10;

        private Timer timeAlive;
        private IHitEffect[] hitEffects;
        private bool alive;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            timeAlive = Timer.CreateAndStart();
            hitEffects = GetComponents<IHitEffect>();
        }

        public void Shoot(Vector3 direction)
        {
            rb.velocity = direction * speed;
        }

        protected override void OnTriggered(IHittable hittable)
        {
            if (!alive)
                return;

            foreach (var effect in hitEffects)
            {
                effect.OnHit(hittable);
            }

            if (killOnHit)
                Kill();
        }

        private void Update()
        {
            if (alive && timeAlive.ElapsedSeconds > autoKillTimer)
                Kill();
            transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        }

        private void Kill()
        {
            alive = false;
            transform.DOScale(Vector3.zero, .25f).OnComplete(Cleanup);
        }

        private void Cleanup()
        {
            Destroy(gameObject);
        }

        public static Bullet Shoot(Bullet prefab, Vector3 origin, Vector3 direction)
        {
            var bullet = Instantiate(prefab);

            bullet.transform.position = origin;
            bullet.Shoot(direction);
            return bullet;
        }
    }
}