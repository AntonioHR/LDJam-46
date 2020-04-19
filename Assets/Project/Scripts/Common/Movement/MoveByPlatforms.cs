using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using JammerTools.Common;

namespace JammerTools.Movement
{
    public class MoveByPlatforms
    {
        private class Tracking
        {
            public MovingPlatform platform;
            public Vector3 lastPos;

            public void ApplyDeltaTo(MoveByPlatforms moveByPlatforms)
            {
                var pos = platform.transform.position;
                var delta = pos - lastPos;
                lastPos = pos;

                moveByPlatforms.charController.Move(delta);
            }
        }

        private CharacterController charController;
        private PlatformCheckArea platformCheckArea;
        private Tracking trackedObject;

        public MoveByPlatforms(CharacterController charController, PlatformCheckArea platformCheckArea)
        {
            this.charController = charController;
            this.platformCheckArea = platformCheckArea;

            platformCheckArea.ObjectEntered += ObjectsChanged;
            platformCheckArea.ObjectLeft += ObjectsChanged;
        }

        private void ObjectsChanged(MovingPlatform obj)
        {
            FindObject();
        }

        private Tracking BuildTrackObject(MovingPlatform platform)
        {
            if (platform == null)
                return null;

            return new Tracking()
            {
                platform = platform,
                lastPos = platform.transform.position
            };

        }

        public void LateUpdate()
        {
            trackedObject?.ApplyDeltaTo(this);
        }
        public void Reset()
        {
            FindObject();
        }
        private void FindObject()
        {
            var platPos = platformCheckArea.transform.position;
            var closest = platformCheckArea.ObjectsInArea
                .WithMinValue(plat =>
                    Vector3.Distance(plat.transform.position, platPos));

            if (trackedObject?.platform != closest)
                trackedObject = BuildTrackObject(closest);
        }

    }
}