using System.Collections;
using Xamarin.Forms;

namespace XFEmptyListMessage.Controls
{
    public class StaticListViewWithEmptyMessage : Grid
    {
        public ListView ListView
        {
            get { return (ListView)GetValue(ListViewProperty); }
            set { SetValue(ListViewProperty, value); }
        }

        public static readonly BindableProperty ListViewProperty =
            BindableProperty.Create(nameof(ListView), typeof(ListView), typeof(StaticListViewWithEmptyMessage), propertyChanged: HandleListViewChanged);

        static void HandleListViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var intelligentListView = (StaticListViewWithEmptyMessage)bindable;
            var oldList = (ListView)oldValue;

            if(oldList != null)
            {
                intelligentListView.Children.Remove(oldList);
                oldList.PropertyChanged -= ListViewPropertyChanged;
            }

            var newList = (ListView)newValue;
            newList.IsVisible = false;
            newList.PropertyChanged += ListViewPropertyChanged;

            intelligentListView.Children.Add(newList);
        }

        static void ListViewPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != ListView.ItemsSourceProperty.PropertyName) return;

            var listView = (ListView)sender;
            var staticListViewWithEmptyMessage = listView.Parent as StaticListViewWithEmptyMessage;

            if (listView.ItemsSource == null || (listView.ItemsSource as ICollection).Count == 0)
            {
                listView.IsVisible = false;
                staticListViewWithEmptyMessage.emptyMessageLbl.IsVisible = true;
            }
            else
            {
                listView.IsVisible = true;
                staticListViewWithEmptyMessage.emptyMessageLbl.IsVisible = false;
            }
        }

        public string EmptyMessage
        {
            get { return (string)GetValue(EmptyMessageProperty); }
            set { SetValue(EmptyMessageProperty, value); }
        }

        public static readonly BindableProperty EmptyMessageProperty =
            BindableProperty.Create(nameof(EmptyMessage), typeof(string), typeof(StaticListViewWithEmptyMessage));

        readonly Label emptyMessageLbl;

        public StaticListViewWithEmptyMessage()
        {
            Children.Add(emptyMessageLbl = GenerateEmptyLabel());
        }

        Label GenerateEmptyLabel()
        {
            var lbl = new Label
            {
                BindingContext = this, 
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Italic
            };

            lbl.SetBinding(Label.TextProperty, EmptyMessageProperty.PropertyName);
            return lbl;
        }
    }
}
