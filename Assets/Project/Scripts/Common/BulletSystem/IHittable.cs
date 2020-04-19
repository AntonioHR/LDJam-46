using UnityEngine;

namespace JammerTools.BulletSystem
{
    public interface IHittable
    {

        bool IgnoresHits { get; }
        T GetComponent<T>();
    }
}