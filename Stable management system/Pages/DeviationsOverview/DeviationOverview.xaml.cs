﻿using Stable_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stable_management_system.Pages.Deviations
{
    /// <summary>
    /// Interaction logic for DeviationOverview.xaml
    /// </summary>
    public partial class DeviationOverview : Page
    {
        DeviationsViewModel dvm = new DeviationsViewModel();
        public DeviationOverview()
        {
            InitializeComponent();
            DataContext = dvm;
        }

       
    }
}
