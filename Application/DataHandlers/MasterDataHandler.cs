using Application.DataHandlers.DomæneDatahandler;
using Application.Repostories;
using Kallesstaldsystem.Model;
using System.Text;
using static Kallesstaldsystem.Model.Horse;

namespace Application.DataHandlers
{
    public class MasterDataHandler
    {
        private HorseDatahandler _horseDataHandler = new HorseDatahandler();

     

        public void Read()
        {
            _horseDataHandler.ReadHorses();

        }
        public void Write()
        {
            _horseDataHandler.WriteHorses();
        }

       

        public void ReadOwners()
        {
            //TODO
        }
        public void WriteOwners()
        {
            //TODO
        }



    }
}
