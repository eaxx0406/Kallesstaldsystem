using ApplicationLayer.Controllers;
using Kallesstaldsystem.Model;
using Stable_management_system.Commands;
using Stable_management_system.Commands.HorseOwnerCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stable_management_system.ViewModels
{
    public class HorseOwnerMainViewModel
    {
        private HorseOwnerController _horseOwnerController { get; set; }
        public ObservableCollection<HorseOwner> HorseOwners { get; set; } = new ObservableCollection<HorseOwner>();
        public HorseOwner SelectedHorseOwner { get; set; }
        public string SearchForHorseOwner { get; set; }
       
        public HorseOwnerMainViewModel()
        {
            _horseOwnerController = new HorseOwnerController();
            LoadHorseOwners();
        }

        public void LoadHorseOwners()
        {
            HorseOwners.Clear();
            List<HorseOwner> TempHorseOwners = _horseOwnerController.GetAll();
            foreach (HorseOwner horseOwner in TempHorseOwners)
            {
                HorseOwners.Add(horseOwner);
            }
        }
        public void LoadHorseOwners(string searchFor)
        {
            HorseOwners.Clear();
            List<HorseOwner> TempHorseOwners = _horseOwnerController.GetAll();
            foreach (HorseOwner horseOwner in TempHorseOwners)
            {
                string HorseOwnernameAllLower = horseOwner.Name.ToLower();
                if (HorseOwnernameAllLower.Contains(searchFor.ToLower()))
                {
                    HorseOwners.Add(horseOwner);
                }
            }
        }
        public void AddHorseOwner(HorseOwner horseOwner)
        {
            _horseOwnerController.Add(horseOwner);
            HorseOwners.Add(horseOwner);
        }
        public void RemoveSelectedHorseOwner(int id)
        {
            _horseOwnerController.Remove(id);
            HorseOwners.Remove(SelectedHorseOwner);
        }
        public void Update(HorseOwner horseOwner)
        {
            _horseOwnerController.Update(horseOwner);
        }
        public ICommand CreateHorseOwnerCMD { get; set; } = new CreateHorseOwnerCommand();
        public ICommand DeleteHorseOwnerCMD { get; set; } = new DeleteHorseOwnerCommand();
        public ICommand SearchHorseOwnerCMD { get; set; } = new SearchHorseOwnerCommand();
        public ICommand UpdateHorseOwnerCMD { get; set; } = new UpdateHorseOwnerCommand();
    }
}

