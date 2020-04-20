using JammerTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleGame.WaterSystem
{
    public class PlantAreaManager : MonoSingleton<PlantAreaManager>
    {
        private List<PlantArea> plantAreas = new List<PlantArea>();
        private int completed;

        public IEnumerable<PlantArea> AllAreas => plantAreas.AsReadOnly();

        public event PlantArea.PlantAreaHandler AnyPlantAreaComplete;

        public event Action AllPlantAreasComplete;


        public void Register(PlantArea plantArea)
        {
            plantAreas.Add(plantArea);

            plantArea.Complete += OnPlantAreaComplete;
        }

        private void OnPlantAreaComplete(PlantArea plantArea)
        {
            AnyPlantAreaComplete?.Invoke(plantArea);

            completed++;
            if(completed == plantAreas.Count)
            {
                AllPlantAreasComplete?.Invoke();
            }
        }
    }
}
