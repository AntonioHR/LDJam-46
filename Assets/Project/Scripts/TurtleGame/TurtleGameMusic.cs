using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleGame.WaterSystem;
using UnityEngine;

namespace TurtleGame
{
    public class TurtleGameMusic : MonoBehaviour
    {

        public AudioSource[] sources;

        [SerializeField]
        private bool useCustom;
        [SerializeField]
        private float[] customValues;
        [SerializeField]
        private float transitionTime = .5f;
        [SerializeField]
        private float start = 0.5f;
        private int complete;

        Tween transition;

        public float AreaCount { get => PlantAreaManager.Instance.AllAreas.Count(); }


        private void Start()
        {
            PlantAreaManager.Instance.AnyPlantAreaComplete += AnyPlantAreaComplete;

            if (useCustom)
                Debug.Assert(customValues.Length == PlantAreaManager.Instance.AllAreas.Count());

            SetValue(start);
            transition.Complete();

        }

        private void AnyPlantAreaComplete(PlantArea plantArea)
        {
            complete++;

            if(useCustom)
            {
                SetValue(customValues[complete-1]);

            } else

            {
                float alpha = complete / (float)AreaCount;
                SetValue(Mathf.Lerp(start, sources.Length, alpha));
            }
        }


        private void SetValue(float f)
        {
            transition?.Kill();


            var seq = DOTween.Sequence();

            for (int i = 0; i < sources.Length; i++)
            {
                float val = Mathf.Clamp(f - i, 0, 1);

                seq.Append(sources[i].DOFade(val, transitionTime));
            }


            transition = seq;
        }
    }
}
