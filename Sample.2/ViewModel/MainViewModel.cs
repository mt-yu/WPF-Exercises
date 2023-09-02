using CommunityToolkit.Mvvm.ComponentModel;
using Sample._2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample._2.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Title = "Sample 2";
            CreateMenu();
        }

        private void CreateMenu()
        {
            Menus = new ObservableCollection<MenuModel>()
            {
                new MenuModel(){ Icon = "\xe608", Name = "Live scores" },
                new MenuModel(){ Icon = "\xe620", Name = "Series" },
                new MenuModel(){ Icon = "\xe622", Name = "Teams" },
                new MenuModel(){ Icon = "\xe603", Name = "Features" },
                new MenuModel(){ Icon = "\xe51c", Name = "Videos" },
                new MenuModel(){ Icon = "\xe790", Name = "Stats" },
                new MenuModel(){ Icon = "\xe672", Name = "World Cup 2019" },
            };
        }

        public string Title { get; set; }

        private ObservableCollection<MenuModel> meuns;

        public ObservableCollection<MenuModel> Menus
        {
            get { return meuns; }
            set { meuns = value; OnPropertyChanged(); }
        }

    }
}
