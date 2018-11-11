using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFEmptyListMessage.ViewModels
{
    public class TheVMWayViewModel : BaseViewModel
    {
        List<string> data;
        public List<string> Data
        {
            get => data;
            set
            {
                data = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsNotEmptyData));
            }
        }

        public bool IsNotEmptyData => data != null && data.Count > 0;

        public ICommand SetNotEmpyListCommand { get; }
        public ICommand SetEmptyListCommand { get; }

        public TheVMWayViewModel()
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
