using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFEmptyListMessage.ViewModels
{
    public class ReusableWayViewModel : BaseViewModel
    {
        List<string> data;
        public List<string> Data
        {
            get => data;
            set
            {
                data = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SetNotEmpyListCommand { get; }
        public ICommand SetEmptyListCommand { get; }

        public ReusableWayViewModel()
        {
            SetNotEmpyListCommand = new Command(() =>
            {
                Data = new List<string>
                {
                    "Hello",
                    "World"
                };
            });

            SetEmptyListCommand = new Command(() => Data = new List<string>());
        }
    }
}
