using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.BulletSystem
{
    public class Obstacle : MonoBehaviour,  IHittable
    {
        public bool IgnoresHits => false;
    }
}
