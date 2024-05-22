using Stable_management_system.Commands;
using ApplicationLayer;
using ApplicationLayer.Controllers;
using Kallesstaldsystem.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Dynamic;
using System.ComponentModel;

namespace Stable_management_system.ViewModels
{
    public class HorseMainViewModel 
    {
        private HorseController _horseController { get; set; }
        public ObservableCollection<Horse> Horses { get; set; } = new ObservableCollection<Horse>();
        public Horse SelectedHorse { get; set; }
        public FeedingScheduel SelectedHorsesFeedingScheduel { get; set; }
        public string SelectedHorsePaddockName { get; set; } = "Ikke sat";
        public string SelectedHorseOwnerPhone { get; set; } = "Ikke Sat";
        public string SelectedHorseOwnerName { get; set; } = "Ikke Sat";
        public string SearchForHorse {  get; set; }

        public HorseMainViewModel()
        {
            _horseController = new HorseController();
            LoadHorses();   
        }

        public void LoadHorses()
        {
            Horses.Clear();
            List<Horse> TempHorses = _horseController.GetAll();
            foreach (Horse horse in TempHorses)
            {
                Horses.Add(horse);

            }
        }
        public void LoadHorses(string searchFor)
        {
            Horses.Clear();
            List<Horse> TempHorses = _horseController.GetAll();
            foreach (Horse horse in TempHorses)
            {
                string HorsenameAllLower = horse.Name.ToLower();
                if (HorsenameAllLower.Contains(searchFor.ToLower()))
                {
                    Horses.Add(horse);
                }
            }
        }

        public void Update(Horse horse)
        {
            _horseController.Update(horse);
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
        public ICommand SearchHorseCMD { get; set; } = new SearchHorseCommand();
        public ICommand UpdateHorseCMD { get; set; } = new UpdateHorseCommand();

        public void GetSelectedFeedingScheduel()
        {
            FeedingScheduelController feedingScheduelController = new FeedingScheduelController();
            List<FeedingScheduel> allFeedingschduels = feedingScheduelController.GetAll();
            foreach (FeedingScheduel feedingscheduel in allFeedingschduels)
            {
                if (feedingscheduel.Id == SelectedHorse.FeedingScheduelId)
                {
                    SelectedHorsesFeedingScheduel = feedingscheduel;
                }
            }
        }

        public void GetPaddockName()
        {
            PaddockController paddockController = new PaddockController();
            List<Paddock> allPaddocks = paddockController.GetAll();
            foreach (Paddock paddock in allPaddocks)
            {
                if (paddock.Id == SelectedHorse.PaddockId)
                {
                    SelectedHorsePaddockName = paddock.Name;
                }
            }
        }

        public void GetOwnerInfo()
        {
            HorseOwnerController horseOwnerController = new HorseOwnerController();
            List<HorseOwner> allHorseOwners = horseOwnerController.GetAll();
            foreach (HorseOwner horseOwner in allHorseOwners)
            {
                if (horseOwner.Id == SelectedHorse.OwnerId)
                {
                    SelectedHorseOwnerName = horseOwner.Name;
                    SelectedHorseOwnerPhone = horseOwner.Phone;
                }
            }
        }
    }
}


