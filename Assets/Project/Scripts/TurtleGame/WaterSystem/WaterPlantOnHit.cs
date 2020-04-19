using JammerTools.BulletSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TurtleGame.WaterSystem
{
    public class WaterPlantOnHit : HitEffectBase<Plant>
    {
        [SerializeField]
        private float wateramount;

        protected override void OnHit(Plant plant)
        {
            plant.GiveWater(wateramount);
        }
    }
}
