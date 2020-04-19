using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.Tweens
{
    public class RotateByTween : MonoBehaviour
    {
        [SerializeField]
        private Vector3 rotation= new Vector3(0, 1, 0);
        [SerializeField]
        private float period = 1;
        [SerializeField]
        private float interval = 0;
        [SerializeField]
        private Ease easing = Ease.Linear;
        private Tween tween;

        private void Start()
        {
            var seq = DOTween.Sequence();

            var tween = transform.DOLocalRotate(rotation, period)
                .SetRelative()
                .SetEase(easing);

            seq.Append(tween);
            if(interval > 0)
                seq.AppendInterval(interval);
            seq.SetLoops(-1);

        }
        private void OnDestroy()
        {
            tween?.Kill();
        }
    }
}
