using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kallesstaldsystem.Model.Horse;

namespace Stable_management_system
{
    internal class Localizations
    {
        public Dictionary<string, string> Translations = new Dictionary<string, string>();

        public Localizations()
        {
            Translations.Add("Horse", "Hest");
            Translations.Add("Owner", "Ejer");
            Translations.Add("Box", "Boks");
            Translations.Add("Paddock", "Fold");
            Translations.Add("FeedingScheduel", "Fodringsplan");
            Translations.Add("AddOn", "Tilføjelse");
            Translations.Add("Deviation", "Afvigelse");
            Translations.Add("Name", "Navn");
            Translations.Add("CHRId", "CHRId");
            Translations.Add("HorseType", "Hestetype");
            Translations.Add(Enum.GetName(typeof(Gender), Gender.Mare), "Hoppe");
            Translations.Add(Enum.GetName(typeof(Gender), Gender.Gelding), "Vallak");
            Translations.Add(Enum.GetName(typeof(Gender), Gender.Stallion), "Hingst");
            Translations.Add(Enum.GetName(typeof(Gender), Gender.Unknown), "Ukendt køn");
            Translations.Add(Enum.GetName(typeof(EquineType), EquineType.Pony), "Pony");
            Translations.Add(Enum.GetName(typeof(EquineType), EquineType.Horse), "Hest");
            Translations.Add(Enum.GetName(typeof(EquineType), EquineType.Unknown), "Ukendt type");

        }
    }
}
