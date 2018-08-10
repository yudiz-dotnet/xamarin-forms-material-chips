using MaterialChips.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MaterialChips.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        #region Local Variables
        Constants.ColorConstants color = new Constants.ColorConstants();
        private ViewModels.MainPageViewModel _MainPageViewModel;
        public static List<Items> _ItemList;
        #endregion

        #region Constructor
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _MainPageViewModel = new ViewModels.MainPageViewModel(); // Binding ViewModel

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);   // This is used to give space in iPhone X for safe Area

            _ItemList = _MainPageViewModel.ItemList;  // Binding Itemlist from Viewmodel List

            foreach (var items in _ItemList)
            {
                flChipView.Children.Add(CreateRandomBoxview(items));  // Creating a chip with one value of ItemList
            }
        }
        #endregion

        #region Functions For Create Chips
        private Frame CreateRandomBoxview(Items items)
        {
            var view = new Frame();    // Creating New View for design as chip
            view.BackgroundColor = (items.IsClicked) ? (Color)color["White"] : (Color)color["Purple"];
            view.BorderColor = (items.IsClicked) ? (Color)color["Purple"] : (Color)color["White"];
            view.Padding = new Thickness(20, 10);
            view.CornerRadius = 20;
            view.HasShadow = false;

            //Chip click event
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                var frameSender = (Frame)s;
                var labelDemo = (Label)frameSender.Content;
                if (!items.IsClicked)
                {
                    view.BackgroundColor = (Color)color["White"];
                    labelDemo.TextColor = (Color)color["Purple"];
                    view.BorderColor = (Color)color["Purple"];
                    items.IsClicked = true;
                }
                else if (items.IsClicked)
                {
                    view.BackgroundColor = (Color)color["Purple"];
                    labelDemo.TextColor = (Color)color["White"];
                    view.BorderColor = (Color)color["White"];
                    items.IsClicked = false;
                }
            };
            view.GestureRecognizers.Add(tapGestureRecognizer);

            // creating new child that holds the value of item list and add in View
            var label = new Label();
            label.Text = items.ItemName;
            label.TextColor = (items.IsClicked) ? (Color)color["Purple"] : (Color)color["White"];
            label.HorizontalOptions = LayoutOptions.Center;
            label.VerticalOptions = LayoutOptions.Center;
            label.FontSize = 20;
            view.Content = label;
            return view;
        }
        #endregion
    }
}