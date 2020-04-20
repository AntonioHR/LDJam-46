using JammerTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.Music
{
    [AddComponentMenu("JammerMusic/Music Disable Trigger")]
    public class DisableMusicTrigger : MonoTrigger
    {
        protected override void OnTriggered()
        {
            MusicManager.Instance.DisableMusic();
        }
    }
}
