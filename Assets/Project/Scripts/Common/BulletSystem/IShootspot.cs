using UnityEngine;

namespace TurtleGame.Player
{
    public interface IShootSpot
    {
        Vector3 Origin { get; }
        Vector3 Direction { get; }
    }
}