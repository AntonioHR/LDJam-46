using DG.Tweening;
using JammerTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace JammerTools.Tweens
{
    [RequireComponent(typeof(Image))]
    public class FadeTweenTrigger : MonoTrigger
    {
        [SerializeField]
        private float value = 1;
        [SerializeField]
        private float duration = .5f;
        [SerializeField]
        private bool fromValue = false;



        private Tween tween;
        private Image img;
        private void Awake()
        {
            img = GetComponent<Image>();
        }

        protected override void OnTriggered()
        {
            tween?.Kill();

            tween = BuildTween();
        }

        private Tween BuildTween()
        {
            var result = img.DOFade(value, duration);
            if(fromValue)
                result.From();

            return result;
        }

        private void OnDestroy()
        {
            tween?.Kill();
        }

    }
}
