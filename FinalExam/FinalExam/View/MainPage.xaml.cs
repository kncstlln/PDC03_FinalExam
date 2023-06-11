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
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ListAnimal(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListAnimal());
        }
    }
}