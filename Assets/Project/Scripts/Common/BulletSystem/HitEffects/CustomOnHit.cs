using JammerTools.BulletSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace JammerTools.BulletSystem
{
    public class CustomOnHit : HitEffectBase
    {
        public UnityEvent unityEvent;
        public override void OnHit(IHittable hittable)
        {
            unityEvent.Invoke();
        }
    }
}
