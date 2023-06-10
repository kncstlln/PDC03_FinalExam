using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalExam.ViewModel;
using FinalExam.Model;

namespace FinalExam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        AnimalViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new AnimalViewModel();
        }

        private void showAnimalPage()
        {
            var res = viewModel.GetAllAnimal().Result;
            lstData.ItemsSource = res;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showAnimalPage();
        }

        private void btnAddRecord_Clicked(Object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddAnimal());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Animal obj = (Animal)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddAnimal(obj));
                        break;

                    case "Delete":
                        viewModel.DeleteAnimal(obj);
                        showAnimalPage();
                        break;
                }
            }
        }
    }
}