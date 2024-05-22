using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer;
using ApplicationLayer.Controllers;
using Kallesstaldsystem.Model;

namespace Stable_management_system.ViewModels
{
    internal class PaddockMainViewModel
    {
        private PaddockController _paddockController {  get; set; }
        private HorseController _horseController { get; set; }
        public ObservableCollection<Paddock> Paddocks { get; set; } = new ObservableCollection<Paddock>();
     

        public PaddockMainViewModel() 
        {
            _paddockController = new PaddockController();
            LoadPaddocks();
        }

        public void LoadPaddocks()
        {
            Paddocks.Clear();
            List<Paddock> TempPaddock = _paddockController.GetAll();
            foreach (Paddock paddock in TempPaddock)
            {
                Paddocks.Add(paddock);
            }
        }

        public Paddock SelectedPaddock { get; set; }
        public ObservableCollection<Horse> HorsesOnSelectedPaddock { get; set; } = new ObservableCollection<Horse>();

        public void GetHorsesOnSelectedPaddock()
        {
            HorsesOnSelectedPaddock.Clear();
            _horseController = new HorseController();
            List<Horse> allHorses = _horseController.GetAll();
            foreach (Horse horse in allHorses)
            {
                if (horse.PaddockId == SelectedPaddock.Id)
                {
                    HorsesOnSelectedPaddock.Add(horse);
                }
            }
        }

    }
}
