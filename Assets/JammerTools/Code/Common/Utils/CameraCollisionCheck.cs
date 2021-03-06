﻿using System;
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
        [SerializeField]
        private LayerMask layerMask;
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

            float dist = targetPosLocal.magnitude;

            if (Physics.Raycast(ray, out RaycastHit hitInfo, cameraDistance, layerMask.value))
            {
                Vector3 toCam = camTransform.TransformVector(hitInfo.point - transform.position);

                float toCamDist = toCam.magnitude;
                if(toCamDist > 0)
                {
                    dist = Mathf.Min(targetPosLocal.magnitude, toCamDist);

                }
            }
            camTransform.localPosition = targetPosLocal.normalized * dist;
        }
    }
}
