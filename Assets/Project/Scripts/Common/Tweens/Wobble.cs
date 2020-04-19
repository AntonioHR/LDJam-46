using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.Tweens
{
    public class Wobble : MonoBehaviour
    {
        [SerializeField]
        private Vector3 wobble = new Vector3(0, 1, 0);
        [SerializeField]
        private float period = 1;
        [SerializeField]
        private Ease easing = Ease.InOutSine;
        private Tween tween;

        private void Start()
        {
            var seq = DOTween.Sequence();
            transform.position -= wobble / 2;
            var up = transform.DOMove(wobble, period / 4)
                .SetEase(easing)
                .SetRelative()
                .SetLoops(2, LoopType.Yoyo);
            seq.Append(up);

            seq.SetLoops(-1);
            tween = seq;
        }
        private void OnDestroy()
        {
            tween?.Kill();
        }
    }
}
