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
        private AnimalViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new AnimalViewModel();
            BindingContext = viewModel;
        }
    }
}