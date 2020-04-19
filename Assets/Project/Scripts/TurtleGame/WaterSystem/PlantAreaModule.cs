using JammerTools.Common;
using UnityEngine;
using UnityEngine.Events;

namespace TurtleGame.WaterSystem
{
    public class PlantAreaModule : MonoBehaviour
    {

        [SerializeField]
        private UnityEvent afterEnable;
        [SerializeField]
        private string animationTrigger;
        [SerializeField]
        private bool fireAllTriggers;
        private Animator animator;

        private void Awake()
        {
            gameObject.SetActive(false);
            animator = GetComponent<Animator>();
        }
        public void OnPlantAreaActivate()
        {
            gameObject.SetActive(true);

            afterEnable.Invoke();

            if(animator!= null && animationTrigger.Length > 0)
            {
                animator.SetTrigger(animationTrigger);
            }

            if(fireAllTriggers)
            {
                foreach (var trigger in GetComponents<MonoTrigger>())
                {
                    trigger.Fire();
                }
            }
        }
    }
}