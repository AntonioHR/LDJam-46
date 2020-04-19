using DG.Tweening;
using JammerTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.Tweens
{
    public class MoveTweenTrigger : MonoTrigger
    {
        [SerializeField]
        private Vector3 move = new Vector3(0, 1, 0);
        [SerializeField]
        private float time = 1;
        [SerializeField]
        private bool local = false;
        [SerializeField]
        private bool from = false;
        [SerializeField]
        private bool relative = true;
        [SerializeField]
        private Ease easing = Ease.InOutSine;
        private Tweener tween;

        protected override void OnTriggered()
        {
            tween?.Kill();

            tween = local?
                transform.DOMove(move, time)
                :transform.DOLocalMove(move, time);

            tween.SetEase(easing)
                .SetRelative(true);
            if (from)
                tween.From();
        }
        private void OnDestroy()
        {
            tween?.Kill();
        }

    }
}
