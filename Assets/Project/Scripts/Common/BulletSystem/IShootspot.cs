using UnityEngine;

namespace JammerTools.BulletSystem
{
    public interface IShootSpot
    {
        Vector3 Origin { get; }
        Vector3 Direction { get; }
    }
}