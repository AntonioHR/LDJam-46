using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JammerTools.Common
{
    public class SceneChangeTrigger : MonoTrigger
    {
        public enum Mode { Name, Index }
        [SerializeField]
        private Mode mode;
        [SerializeField]
        private string sceneName;
        [SerializeField]
        private int sceneIndex = -1;

        protected override void OnTriggered()
        {
            switch (mode)
            {
                case Mode.Name:
                    SceneManager.LoadScene(sceneName);
                    break;
                case Mode.Index:
                    SceneManager.LoadScene(sceneIndex);
                    break;
                default:
                    break;
            }
        }
    }
}
