using Xamarin.Forms;
using XFEmptyListMessage.ViewModels;

namespace XFEmptyListMessage
{
    public partial class TheVMWayPage : ContentPage
    {
        public TheVMWayPage()
        {
            InitializeComponent();
            BindingContext = new TheVMWayViewModel();
        }
    }
}
