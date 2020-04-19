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

        private Color targetColor;
        private Color colorVel;

        private void Start()
        {
            player = GetComponentInParent<PlayerController>();
            img = GetComponent<Image>();
            img.color = DefaultColor;
        }

        private void Update()
        {

            if(player.IsOnOverheat)
            {
                img.fillAmount = 1 - player.HeatAlpha;
                targetColor = OverHeatColor;
            }
            else
            {
                img.fillAmount = 1 - player.HeatAlpha;
                targetColor = Color.Lerp(DefaultColor, OverHeatColor, player.HeatAlpha);
            }
            //img.fillClockwise = player.IsOnOverheat;

            img.color = targetColor;
            //var color = img.color;
            //color.r = Mathf.SmoothDamp(color.r, targetColor.r, ref colorVel.r, .5f);
            //color.g = Mathf.SmoothDamp(color.g, targetColor.g, ref colorVel.g, .5f);
            //color.b = Mathf.SmoothDamp(color.b, targetColor.b, ref colorVel.b, .5f);

            //img.color = color;
        }
    }
}
