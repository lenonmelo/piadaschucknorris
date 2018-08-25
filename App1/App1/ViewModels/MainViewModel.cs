using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using App1.Views;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        public MainViewModel() : base("ChuckForms")
        {
            RefreshCommand = new Command(async () => await LoadData(), () => !IsBusy);
            ItemClickCommand = new Command<string>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        public override async Task Initialize(object parameters = null) => await LoadData();

        async Task ItemClickCommandExecuteAsync(string category)
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var jokePage = new JokePage();
                await jokePage.ViewModel.Initialize(category);

                await Navigation.PushAsync(jokePage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var categories = await Api.GetAllCategoriesAsync();

                Categories.Clear();
                foreach (var category in categories)
                    Categories.Add(category);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }
    }
}
