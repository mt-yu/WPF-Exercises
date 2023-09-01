using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sample._1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample._1.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Title = "Mt Wpf Ui Sample.1";

            CreateTestData();
            SeeAllCommand = new RelayCommand(SeeAll);
        }

        private void SeeAll()
        {
            CreateTestData();
        }

        public RelayCommand SeeAllCommand { get; set; }

        private void CreateTestData()
        {
            Users = new ObservableCollection<UserModel>()
            {
                new UserModel() { UserName = "James Bloor", FilePath="Images/Image1.jpg", Content="What's up", SignTime="32 min", Status=1},
                new UserModel() { UserName = "Fionn Whitehead", FilePath="Images/Image2.jpg", Content="Nice one", SignTime="2 days", Status = 1},
                new UserModel() { UserName = "Damien Bonnard", FilePath="Images/Image3.jpg", Content="Go on in comi", SignTime="1 week", Status = 1},
                new UserModel() { UserName = "Aneurin Barnard", FilePath="Images/Image4.jpg", Content="I am coming", SignTime="2 weeks", Status = 1},
                new UserModel() { UserName = "James Bloor", FilePath="Images/Image1.jpg", Content="What's up", SignTime="3 weeks", Status = 0},
                new UserModel() { UserName = "Fionn Whitehead", FilePath="Images/Image2.jpg", Content="Nice one", SignTime="4 weeks", Status = 0},
                new UserModel() { UserName = "Damien Bonnard", FilePath="Images/Image3.jpg", Content="Go on in comi", SignTime="1 month", Status = 0},
                new UserModel() { UserName = "Aneurin Barnard", FilePath="Images/Image4.jpg", Content="I am coming", SignTime="3 months", Status = 0},
            };

            Transactions = new ObservableCollection<TransactionModel>()
            {
                new TransactionModel() {Id = 2231, Avatar="Images/Image1.jpg", Name="James Bloor", Date="07.12.2019", Amount="$32"},
                new TransactionModel() {Id = 2230, Avatar="Images/Image2.jpg", Name="Fionn Whitehead", Date="07.12.2019", Amount="$322"},
                new TransactionModel() {Id = 2229, Avatar="Images/Image3.jpg", Name="Damien Bonnard", Date="07.12.2019", Amount="$22"},
                new TransactionModel() {Id = 2228, Avatar="Images/Image4.jpg", Name="Aneurin Barnard", Date="07.12.2019", Amount="$45"},
                new TransactionModel() {Id = 2222, Avatar="Images/Image1.jpg", Name="James Bloor", Date="07.12.2019", Amount="$32"},
                new TransactionModel() {Id = 3333, Avatar="Images/Image2.jpg", Name="Fionn Whitehead", Date="07.12.2019", Amount="$322"},
                new TransactionModel() {Id = 4444, Avatar="Images/Image3.jpg", Name="Damien Bonnard", Date="07.12.2019", Amount="$22"},
                new TransactionModel() {Id = 5555, Avatar="Images/Image4.jpg", Name="Aneurin Barnard", Date="07.12.2019", Amount="$45"},
                 new TransactionModel() {Id = 6666, Avatar="Images/Image1.jpg", Name="James Bloor", Date="07.12.2019", Amount="$32"},
                new TransactionModel() {Id = 7777, Avatar="Images/Image2.jpg", Name="Fionn Whitehead", Date="07.12.2019", Amount="$322"},
                new TransactionModel() {Id = 8888, Avatar="Images/Image3.jpg", Name="Damien Bonnard", Date="07.12.2019", Amount="$22"},
                new TransactionModel() {Id = 9999, Avatar="Images/Image4.jpg", Name="Aneurin Barnard", Date="07.12.2019", Amount="$45"},
            };

        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        private ObservableCollection<UserModel> users;

        public ObservableCollection<UserModel> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TransactionModel> transactions;

        public ObservableCollection<TransactionModel> Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }



    }
}
