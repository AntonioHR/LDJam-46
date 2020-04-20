using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace JammerTools.Common
{
    public class UnityEventTrigger : MonoTrigger
    {
        public UnityEvent ev;
        protected override void OnTriggered()
        {
            ev.Invoke();
        }
    }
}
