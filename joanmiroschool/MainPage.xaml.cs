﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using joanmiroschool.View;
using joanmiroschool.View.Navigation;
using Xamarin.Forms;

namespace joanmiroschool
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
           
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new GeneralPage());
            App.MasterD = this;
        }
    }
}
