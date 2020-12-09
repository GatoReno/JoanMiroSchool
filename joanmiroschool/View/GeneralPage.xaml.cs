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
            tabBottom.BarBackgroundColor = Color.FromHex("#e3e6e8");
            tabBottom.BarTextColor = Color.DarkGray;//.FromHex("#272829");
            //tabBottom.SelectedTabColor = Color.FromHex("#272829");            
            tabStudents.IconImageSource = ImageSource.FromResource("joanmiroschool.Images.icons.kidsicon_w.png");
            tabAnnoucements.IconImageSource = ImageSource.FromResource("joanmiroschool.Images.icons.annoucementicon_w.png");
            tabEvents.IconImageSource = ImageSource.FromResource("joanmiroschool.Images.icons.eventsicon_w.png");
        }
    }
}
