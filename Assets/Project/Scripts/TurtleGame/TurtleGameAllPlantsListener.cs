using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleGame.WaterSystem;
using UnityEngine;
using UnityEngine.Events;

namespace TurtleGame
{
    public class TurtleGameAllPlantsListener : MonoBehaviour
    {

        public UnityEvent ev;
        private void Start()
        {
            PlantAreaManager.Instance.AllPlantAreasComplete += OnAllComplete;

        }

        private void OnDestroy()
        {
        }

        private void OnAllComplete()
        {
            ev?.Invoke();
        }
    }
}
