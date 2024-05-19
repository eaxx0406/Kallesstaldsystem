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
        public ObservableCollection<Horse> Horses { get; set; }

        public Horse SelectedHorse { get; set; }

        public MainViewModel()
        {
            _horseController = new HorseController();
            Horses = new ObservableCollection<Horse>(_horseController.GetAll());
        }

        public void AddHorse(Horse horse)
        {
            _horseController.Add(horse);
            Horses.Add(horse);
        }
        public void RemoveSelectedHorse()
        {
            _horseController.Remove(SelectedHorse.Id);
        }

        public ICommand CreateHorseCMD { get; set; } = new CreateHorseCommand();
        public ICommand DeleteHorseCMD { get; set; } = new DeleteHorseCommand();
    }
}


