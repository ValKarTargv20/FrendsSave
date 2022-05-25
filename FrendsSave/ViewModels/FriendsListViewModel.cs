using FrendsSave.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FrendsSave.ViewModels
{
    class FriendsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FriendsViewModel> Friends { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateFriendCommand { protected set; get; }
        public ICommand DeleteFriendCommand { protected set; get; }
        public ICommand SaveFriendCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        FriendsViewModel selectedFriend;
        public INavigation Navigation { get; set; }

        public FriendsListViewModel()
        {
            Friends = new ObservableCollection<FriendsViewModel>();
            CreateFriendCommand = new Command (CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }

        public FriendsViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if(selectedFriend != value)
                {
                    FriendsViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveFriend(object friendObject)
        {
            FriendsViewModel friend = friendObject as FriendsViewModel;
            if (friend != null && friend.IsValid && !Friends.Contains(friend))
            {
                Friends.Add(friend);
            }
            Back();
        }

        private void DeleteFriend(object friendObject)
        {
            FriendsViewModel friend = friendObject as FriendsViewModel;
            if (friend!= null)
            {
                Friends.Remove(friend);
            }
            Back();
        } 

        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendsViewModel() { ListViewModel = this }));
        }
    }
}
