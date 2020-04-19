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
    public class OneAxisTweenTrigger : MonoTrigger
    {
        enum Axis { X, Y, Z}
        [SerializeField]
        private float move = 1;
        [SerializeField]
        private Axis axis = Axis.X;
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

            tween = BuildTween();

            tween.SetEase(easing)
                .SetRelative(relative);
            if (from)
                tween.From();
        }

        private Tweener BuildTween()
        {
            if(local)
            {
                switch (axis)
                {
                    case Axis.X:
                        return transform.DOLocalMoveX(move, time);
                    case Axis.Y:
                        return transform.DOLocalMoveY(move, time);
                    case Axis.Z:
                        return transform.DOLocalMoveZ(move, time);
                    default:
                        throw new NotImplementedException();
                }
            } else
            {
                switch (axis)
                {
                    case Axis.X:
                        return transform.DOMoveX(move, time);
                    case Axis.Y:
                        return transform.DOMoveY(move, time);
                    case Axis.Z:
                        return transform.DOMoveZ(move, time);
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void OnDestroy()
        {
            tween?.Kill();
        }

    }
}
