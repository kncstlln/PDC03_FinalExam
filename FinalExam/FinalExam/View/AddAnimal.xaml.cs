using FinalExam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalExam.ViewModel;

namespace FinalExam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAnimal : ContentPage
    {
        AnimalViewModel _viewModel;
        bool _isUpdate;
        int animalID;
 


        public AddAnimal()
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            _isUpdate = false; 
        }

        public AddAnimal(Animal obj)
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            if (obj != null)
            {
                animalID = obj.Id;
                txtAnimalCode.Text = obj.AnimalCode;
                txtCharacteristics.Text = obj.Characteristics;
                txtSpecies.Text = obj.Species;
                txtHabitat.Text = obj.Habitat;
                txtThreat.Text = obj.Threat;
                _isUpdate = true;
            }
        }

        // Call Save and Update

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Animal obj = new Animal();
            obj.Id = animalID;
            obj.AnimalCode = txtAnimalCode.Text;
            obj.Characteristics = txtCharacteristics.Text;
            obj.Species = txtSpecies.Text;
            obj.Habitat = txtHabitat.Text;
            obj.Threat = txtThreat.Text;

            if (_isUpdate)
            {
                obj.Id = animalID;
                await _viewModel.UpdateAnimal(obj);
            }
            else
            {
                _viewModel.InsertAnimal(obj);
            }

            await this.Navigation.PopAsync();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListAnimal());
        }
    }
}