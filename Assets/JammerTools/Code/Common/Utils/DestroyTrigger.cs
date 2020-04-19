using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.Common
{
    public class DestroyTrigger : MonoTrigger
    {
        protected override void OnTriggered()
        {
            GameObject.Destroy(gameObject);
        }
    }
}
