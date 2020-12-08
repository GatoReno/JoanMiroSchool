using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace joanmiroschool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralPage : TabbedPage
    {
        public GeneralPage()
        {
            InitializeComponent();
            tabBottom.BarBackgroundColor = Color.FromHex("#5f6a75");
            tabBottom.BarTextColor = Color.DarkGray;
            //tabBottom.SelectedTabColor = Color.FromHex("#272829");
        }
    }
}
