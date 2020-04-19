using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace TurtleGame.Player
{
    [RequireComponent(typeof(Text))]
    class StateDebugText : MonoBehaviour
    {
        private Text text;
        private PlayerController player;

        private void Start()
        {
            text = GetComponent<Text>();
            player = GetComponentInParent<PlayerController>();
        }

        private void LateUpdate()
        {
            text.text = player.DebugStateName;
        }
    }
}
