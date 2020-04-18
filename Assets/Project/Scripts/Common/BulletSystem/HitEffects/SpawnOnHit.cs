using JammerTools.BulletSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.BulletSystem
{
    public class SpawnOnHit : HitEffectBase
    {
        public GameObject prefab;
        public override void OnHit(IHittable hittable)
        {
            var spawn = Instantiate(prefab);

            spawn.transform.position = transform.position;
            spawn.transform.rotation = transform.rotation;
        }
    }
}
