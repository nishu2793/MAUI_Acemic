using AceMicEV.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.ViewModels
{
    public class FirstScreenViewModel 
    {
        #region Properties
        public ObservableCollection<FirstScreenModel> FirstScreens { get; set; } = new ObservableCollection<FirstScreenModel>();
        #endregion
        public ObservableCollection<FirstScreenModel> FirstScreen { get; set; }= new ObservableCollection<FirstScreenModel>();
        public FirstScreenViewModel()
        {
            FirstScreens.Add(new FirstScreenModel
            {
                FirstScreenTitle = "Acemic Charging Station for EV’s",
                FirstScreenDescription = "Our new electric vehicle (EV) charging points has arrived",
                FirstScreenImage = "v1_121"
            });

            FirstScreens.Add(new FirstScreenModel
            {
                FirstScreenTitle = "Looking for Charging Station for your electric vehicle ?",
                FirstScreenDescription = "Acemic is offering EV Charging solutions for users",
                FirstScreenImage = "ddc"
            });
            FirstScreens.Add(new FirstScreenModel
            {
                FirstScreenTitle = "Discover nearby locations to charge your electric vehicle",
                FirstScreenDescription = " ",
                FirstScreenImage = "v1_121"
            });
        }
    }
}
