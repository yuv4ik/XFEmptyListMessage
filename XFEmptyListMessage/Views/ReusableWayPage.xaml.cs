using Xamarin.Forms;
using XFEmptyListMessage.ViewModels;

namespace XFEmptyListMessage
{
    public partial class ReusableWayPage : ContentPage
    {
        public ReusableWayPage()
        {
            InitializeComponent();
            this.BindingContext = new ReusableWayViewModel();
        }
    }
}
