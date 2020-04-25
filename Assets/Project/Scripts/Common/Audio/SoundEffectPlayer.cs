using System;
using JammerTools.Common;
using UnityEngine;

namespace Common.Audio
{
    public class SoundEffectPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        private Timer timer;
        private SoundEffectAsset asset;

        public bool IsPlaying{ get { return TimeSinceLastPlay < asset.clip.length; } }

        public float TimeSinceLastPlay { get => timer != null ? timer.ElapsedSeconds : float.PositiveInfinity; }


        public void Init(SoundEffectAsset asset)
        {
            this.asset = asset;
            ConfigureAudioSource();
        }

        private void ConfigureAudioSource()
        {
            audioSource.clip = asset.clip;
            audioSource.volume = asset.volume;
            audioSource.outputAudioMixerGroup = asset.output;
        }

        public void Play()
        {
            audioSource.Play();
            timer = Timer.CreateAndStart();
        }
    }
}