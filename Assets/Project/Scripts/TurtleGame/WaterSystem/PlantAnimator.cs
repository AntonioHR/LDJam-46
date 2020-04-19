using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TurtleGame.WaterSystem
{
    [RequireComponent(typeof(Plant))]
    [RequireComponent(typeof(Animator))]
    public class PlantAnimator : MonoBehaviour
    {
        public const string ProgressVariable = "Water";
        private Animator animator;
        private Plant plant;

        private void Start()
        {
            animator = GetComponent<Animator>();
            plant = GetComponent<Plant>();
            plant.WaterChanged += OnProgressChanged;
            OnProgressChanged(plant.WaterPercent);
        }


        private void OnProgressChanged(float amount)
        {
            animator.SetFloat(ProgressVariable, plant.WaterPercent);
        }
    }
}
