using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.BulletSystem
{
    public abstract class HitEffectBase<T> : MonoBehaviour,  IHitEffect
    {
        public void OnHit(IHittable hittable)
        {
            if(hittable is T)
            {
                OnHit((T)hittable);
            } else
            {
                var target = hittable.GetComponent<T>();
                if(target != null)
                {
                    OnHit(target);
                }
            }
        }

        protected abstract void OnHit(T hittable);
    }

    public abstract class HitEffectBase : MonoBehaviour, IHitEffect
    {
        public abstract void OnHit(IHittable hittable);
    }
}
