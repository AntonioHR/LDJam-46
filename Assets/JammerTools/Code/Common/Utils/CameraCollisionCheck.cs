using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.Common
{
    public class CameraCollisionCheck : MonoBehaviour
    {
        [SerializeField]
        private Transform camTransform;
        private Vector3 targetPosLocal;
        private float cameraDistance;

        public Vector3 ToTarget { get => camTransform.position - transform.position; }

        private void Start()
        {
            targetPosLocal = camTransform.localPosition;

            cameraDistance = (camTransform.position - transform.position).magnitude;
        }
        private void Update()
        {
            Ray ray = new Ray(transform.position, ToTarget);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, cameraDistance))
            {
                Vector3 toCam = camTransform.TransformVector(hitInfo.point - transform.position);

                float dist = toCam.magnitude;
                if(dist > 0)
                {
                    dist = Mathf.Min(targetPosLocal.magnitude, dist);

                    camTransform.localPosition = targetPosLocal.normalized * dist;
                }
            }
        }
    }
}
