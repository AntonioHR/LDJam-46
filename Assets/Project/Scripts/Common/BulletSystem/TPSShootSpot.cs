using JammerTools.BulletSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.BulletSystem
{
    public class TPSShootSpot : MonoBehaviour, IShootSpot
    {
        [SerializeField]
        private Transform targetRef;
        [SerializeField]
        private Transform gun;
        [SerializeField]
        private Bullet defaultBullet;

        public Vector3 Origin { get => gun.position; }
        public Vector3 Direction { get =>(targetRef.position - gun.position).normalized ; }


        public void ShootDefault()
        {
            Bullet.Shoot(defaultBullet, Origin, Direction);
        }
    }
}
