# xamarin-material-chips
This example is used to create marerial-chips design in xamarin forms MVVM. You can use and customise as per your requirement.

![alt text](Data/iPhone-5s-screenshot.png "iOS screenshot")

# Add Flowlayout Control Code
This flowlayout file is used to create view form Chips. It is like container which contains chips and align as per device size.
   
# Create Content Page
  We have to use FlowLayout control in ContentPage. Here Below code is added that holds the content(Material Chips).

        <ScrollView Grid.Row="0" Padding="10" HorizontalOptions="FillAndExpand" BackgroundColor="White" WidthRequest="50">
            <Controls:FlowLayout x:Name="flChipView" Spacing="5" BackgroundColor="White"/>
        </ScrollView>

# Add ViewModel 
Now, add a code in ViewModel for load data in Material Chips. Here, I have created list of Item which we will add in Chips. 
Here you can use list data as per you need. 

Here, code is written in [MainPageViewModel.cs](../master/Code/MaterialChips/MaterialChips/ViewModels/MainPageViewModel.cs)

    public class MainPageViewModel : BaseViewModel
    {
        private List<Items> _ItemList = new List<Items>();

        public List<Items> ItemList
        {
            get { return _ItemList; }
            set { _ItemList = value; NotifyPropertyChanged("ItemList"); }
        }

        public MainPageViewModel()
        {
            ItemList = new List<Items>()
            {
                ...
                new Items{ItemName="One", IsClicked=true },
                new Items{ItemName="Two", IsClicked=true },
                new Items{ItemName="Three", IsClicked=false },
                new Items{ItemName="Four", IsClicked=true },
                new Items{ItemName="Five", IsClicked=false },
                new Items{ItemName="Six", IsClicked=true },
                ...
                // add items as per your requirement.
            };
        }
    }
    
 # Add Code in MainPage.xml.cs
 In this page, first bind the ViewModel in List. This code is written in [MainPage.xaml.cs](../master/Code/MaterialChips/MaterialChips/Views/MainPage.xaml.cs) 
 
        ...
        private ViewModels.MainPageViewModel _MainPageViewModel;
        public static List<Items> _ItemList;
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _MainPageViewModel = new ViewModels.MainPageViewModel(); // Binding ViewModel
            _ItemList = _MainPageViewModel.ItemList;  // Binding Itemlist from Viewmodel List
        }
        ...
        
In next step, Add CreateRandomBoxview function which creates new Chip for each data in List view.
    
Here, code is written in [MainPage.xaml.cs](../master/Code/MaterialChips/MaterialChips/Views/MainPage.xaml.cs)  file.

        ...   
        private Frame CreateRandomBoxview(Items items)
        {
            var view = new Frame();    // Creating New View for design as chip
            view.BackgroundColor = (items.IsClicked) ? (Color)color["White"] : (Color)color["Purple"];
            view.BorderColor = (items.IsClicked) ? (Color)color["Purple"] : (Color)color["White"];
            view.Padding = new Thickness(20, 10);
            view.CornerRadius = 20;
            view.HasShadow = false;

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
        ...
        
You can also add GestureRecognizers for tapped events on chips. 
        
Here, code is written in [MainPage.xaml.cs](../master/Code/MaterialChips/MaterialChips/Views/MainPage.xaml.cs) file in CreateRandomBoxview function.

         private Frame CreateRandomBoxview(Items items)
         {
           ...
            //Chip click event
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                var frameSender = (Frame)s;
                //Write you logic here...
            };
            view.GestureRecognizers.Add(tapGestureRecognizer);
           ...
         }
        
And in last step, add code in default constructor for creating Chips desgn. See below code that will be add in Material Chips.

Here, code is written in [MainPage.xaml.cs](../master/Code/MaterialChips/MaterialChips/Views/MainPage.xaml.cs) file in default constructor.

        ...
        foreach (var items in _ItemList)
        {
           flChipView.Children.Add(CreateRandomBoxview(items));  // Creating a chip with one value of ItemList
        }
        ...
        
Now, build and run application in device. It is created in MVVM architecture and data are filled dynemically.
