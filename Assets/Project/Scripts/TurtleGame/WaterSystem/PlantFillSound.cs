using JammerTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TurtleGame.WaterSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class PlantFillSound : MonoBehaviour
    {
        [SerializeField]
        private float baseVolume = 1;
        [SerializeField]
        private float fadeDelay = .5f;
        [SerializeField]
        private float fadeRate = .5f;


        private Plant plant;
        private AudioSource audioSource;


        private float lastWater;
        private Timer timer = new Timer();
        private bool isPlaying;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;

            plant = GetComponentInParent<Plant>();
            Debug.Assert(plant != null);

            plant.WaterChanged += OnChange;

            lastWater = plant.Water;
        }

        private void Update()
        {
            if (isPlaying)
            {
                if (timer.ElapsedSeconds > fadeDelay)
                {
                    audioSource.volume -= fadeRate * Time.deltaTime;
                    if (audioSource.volume == 0)
                    {
                        audioSource.Stop();
                        isPlaying = false;
                    }
                }
            }
        }

        private void OnChange(float water)
        {
            if(water > lastWater)
            {
                OnFill();
            }
            lastWater = water;
        }

        private void OnFill()
        {
            if(!isPlaying)
            {
                isPlaying = true;
                audioSource.Play();
            }

            audioSource.volume = baseVolume;
            timer.Restart();
        }
    }
}
