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
    [RequireComponent(typeof(Text))]
    public class TextTweenTrigger : MonoTrigger
    {
        public string message;
        private Text text;
        private Tween tween;
        [SerializeField]
        private float duration = 1;
        [SerializeField]
        private bool speedBasedDuration;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        protected override void OnTriggered()
        {
            tween?.Kill();

            tween = BuildTween();
        }

        private Tween BuildTween()
        {
            var result = text.DOText(message, duration)
                .SetSpeedBased(speedBasedDuration);


            return result;
        }

        private void OnDestroy()
        {
            tween?.Kill();
        }

    }
}
