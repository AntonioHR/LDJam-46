using JammerTools.BulletSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TurtleGame.WaterSystem
{
    public class PlantArea : MonoBehaviour
    {
        public delegate void PlantAreaHandler(PlantArea plantArea);

        public event PlantAreaHandler Complete;

        [SerializeField]
        private PlantArea prev;
        [SerializeField]
        private bool autoActivate = false;


        private Plant[] plants;
        private int fullPlants;
        private bool activated;


        private void Awake()
        {
            PlantAreaManager.Instance.Register(this);
        }
        private void Start()
        {
            if (autoActivate)
                Activate();
            else if (prev != null)
                prev.Complete += (_)=>Activate();
            plants = GetComponentsInChildren<Plant>(true);

            foreach (var plant in plants)
            {
                plant.BecameFull += OnPlantFull;
            }
        }


        public void Activate()
        {
            if (activated)
                return;
            activated = true;
            foreach (var module in GetComponentsInChildren<PlantAreaModule>(true))
            {
                module.OnPlantAreaActivate();
            }
        }

        private void OnPlantFull()
        {
            fullPlants++;
            if(fullPlants == plants.Length)
            {
                OnComplete();
            }
        }

        private void OnComplete()
        {
            Complete?.Invoke(this);
        }
    }
}
