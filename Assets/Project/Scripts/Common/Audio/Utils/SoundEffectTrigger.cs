using JammerTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Common.Audio
{
    public class SoundEffectTrigger : MonoTrigger
    {
        [SerializeField]
        private SoundEffectAsset sound;

        [SerializeField]
        private bool useRandom;

        [SerializeField]
        private SoundEffectAsset[] randomSounds;

        protected override void OnTriggered()
        {
            if (!useRandom)
                sound.Play();
            else
                randomSounds[UnityEngine.Random.Range(0, randomSounds.Length)].Play();
        }
    }
}
