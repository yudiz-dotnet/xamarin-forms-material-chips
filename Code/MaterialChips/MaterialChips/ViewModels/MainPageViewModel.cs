using MaterialChips.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialChips.ViewModels
{
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
                new Items{ItemName="One", IsClicked=true },
                new Items{ItemName="Two", IsClicked=true },
                new Items{ItemName="Three", IsClicked=false },
                new Items{ItemName="Four", IsClicked=true },
                new Items{ItemName="Five", IsClicked=false },
                new Items{ItemName="Six", IsClicked=true },
                new Items{ItemName="Seven", IsClicked=false },
                new Items{ItemName="Eight", IsClicked=true },
                new Items{ItemName="Nine", IsClicked=true },
                new Items{ItemName="Ten", IsClicked=true },
                new Items{ItemName="Eleven", IsClicked=false },
                new Items{ItemName="Tewlve", IsClicked=true },
                new Items{ItemName="Thirteen", IsClicked=true },
                new Items{ItemName="Fourteen", IsClicked=true },
                new Items{ItemName="Fifteen", IsClicked=false },
            };
        }
    }
}
