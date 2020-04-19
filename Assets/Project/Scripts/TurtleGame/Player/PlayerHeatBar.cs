using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace TurtleGame.Player
{
    [RequireComponent(typeof(Image))]
    public class PlayerHeatBar : MonoBehaviour
    {
        private PlayerController player;
        private Image img;
        public Color DefaultColor;
        public Color OverHeatColor;

        private void Start()
        {
            player = GetComponentInParent<PlayerController>();
            img = GetComponent<Image>();
        }

        private void Update()
        {

            if(player.IsOnOverheat)
            {
                img.fillAmount = player.HeatAlpha;
                img.color = OverHeatColor;
            }
            else
            {
                img.fillAmount = 1- player.HeatAlpha;
                img.color = DefaultColor;
            }
            img.fillClockwise = player.IsOnOverheat;
        }
    }
}
