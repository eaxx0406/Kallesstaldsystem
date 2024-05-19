using Stable_management_system.Commands;
using ApplicationLayer;
using ApplicationLayer.Controllers;
using Kallesstaldsystem.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Stable_management_system.ViewModels
{
    public class MainViewModel
    {
        private HorseController _horseController { get; set; }
        public ObservableCollection<Horse> Horses { get; set; } = new ObservableCollection<Horse>();

        public Horse SelectedHorse { get; set; }

        public MainViewModel()
        {
            _horseController = new HorseController();
            LoadHorses();   
        }

        public void LoadHorses()
        {
            List<Horse> TempHorses = _horseController.GetAll();
            foreach (Horse horse in TempHorses)
            {
                Horses.Add(horse);
            }
        }
        public void AddHorse(Horse horse)
        {
            _horseController.Add(horse);
            Horses.Add(horse);
        }
        public void RemoveSelectedHorse(int id)
        {
            _horseController.Remove(id);
            Horses.Remove(SelectedHorse);
        }

        public ICommand CreateHorseCMD { get; set; } = new CreateHorseCommand();
        public ICommand DeleteHorseCMD { get; set; } = new DeleteHorseCommand();
    }
}


