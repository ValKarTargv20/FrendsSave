using FrendsSave.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrendsSave.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendPage : ContentPage
    {
        public FriendsViewModel ViewModel { get; private set; }
        public FriendPage(FriendsViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}