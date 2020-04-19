using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace JammerTools.Common
{
    public abstract class MonoTrigger : MonoBehaviour
    {
        public enum Target { Nothing, Button }

        [SerializeField]
        private bool fireOnStart;
        [SerializeField]
        private float delay = 0;
        [SerializeField]
        private Target AutoTriggerBy;

        private void Start()
        {
            if (fireOnStart)
                Fire();

            SubscribeToAutoTrigger();
        }
        private void OnDestroy()
        {
            UnsubscribeToAutoTrigger();
        }

        private void SubscribeToAutoTrigger()
        {
            switch (AutoTriggerBy)
            {
                case Target.Nothing:
                    break;
                case Target.Button:
                    var bttn = GetComponent<Button>();
                    bttn.onClick.AddListener(Fire);
                    break;
                default:
                    break;
            }
        }

        private void UnsubscribeToAutoTrigger()
        {
            switch (AutoTriggerBy)
            {
                case Target.Nothing:
                    break;
                case Target.Button:
                    var bttn = GetComponent<Button>();
                    bttn.onClick.RemoveListener(Fire);
                    break;
                default:
                    break;
            }
        }

        public void Fire()
        {

            if (delay > 0)
                Wait.ForSecondsThenDo(delay, OnTriggered);
            else
                OnTriggered();
        }
        protected abstract void OnTriggered();
    }
}
