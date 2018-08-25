using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new MainViewModel();

                return (BindingContext as MainViewModel);
            }
        }

        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Initialize(null);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e != null && e.Item != null)
            {
                var categoria = e.Item as string;
                ViewModel?.ItemClickCommand.Execute(categoria);
            } 
        }
    }
}