using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JammerTools.Common
{
    public class SpawnTrigger : MonoTrigger
    {
        public GameObject prefab;
        [SerializeField]
        private bool useRandomOptionsInstead;
        [SerializeField]
        private List<GameObject> randomOptions;
        protected override void OnTriggered()
        {

            var prefab = this.prefab;
            if(useRandomOptionsInstead && randomOptions.Count > 0)
            {
                prefab = randomOptions[UnityEngine.Random.Range(0, randomOptions.Count - 1)];
            }
            var obj = Instantiate(prefab);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
        }
    }
}
