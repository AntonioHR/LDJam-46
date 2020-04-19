using JammerTools.BulletSystem;
using JammerTools.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurtleGame.WaterSystem
{
    public class Plant : MonoBehaviour, IHittable
    {

        [Serializable]
        public class Settings
        {
            public float maxWater = 100;

            public float dehidrateDelay = 2;
            public float dehidrateDecay = 10;
        }

        public delegate void WaterProgressHandler(float amount);

        public event Action BecameFull;
        public event WaterProgressHandler WaterChanged;


        [SerializeField]
        private Settings settings;

        private float water;
        private Timer dehidrateDelay = new Timer();

        public bool IsFull { get; private set; }

        public bool IgnoresHits => IsFull;

        public float Water { get => water; }
        public float WaterPercent { get => water/settings.maxWater; }


        private void Start()
        {
            dehidrateDelay.Restart();
        }

        private void Update()
        {
            UpdateDecay();

        }

        private void UpdateDecay()
        {
            if (IsFull)
                return;
            if (dehidrateDelay.ElapsedSeconds < settings.dehidrateDelay)
                return;

            water -= Time.deltaTime * settings.dehidrateDecay;
            WaterChanged?.Invoke(water);
        }

        public void GiveWater(float delta)
        {
            if (IsFull)
                return;

            this.water += delta;
            this.water = Mathf.Clamp(water, 0, settings.maxWater);

            dehidrateDelay.Restart();

            WaterChanged?.Invoke(this.water);

            if (water >= settings.maxWater)
                OnComplete();
        }

        private void OnComplete()
        {
            BecameFull?.Invoke();
        }
    }

}