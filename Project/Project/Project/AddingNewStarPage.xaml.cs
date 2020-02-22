using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddingNewStarPage : ContentPage
	{
        public AddingNewStarPage ()
		{
			InitializeComponent ();
		}
        public AddingNewStarPage(Star star)
        {
            InitializeComponent();
            
            Star = star;
            NameEntry.Text = Star.Name;
            WeightEntry.Text = Star.Weight.ToString();
            RadiusEntry.Text = Star.Radius.ToString();
            TemperatureEntry.Text = Star.Temperature.ToString();
            LuminosityEntry.Text = Star.Luminosity.ToString();
            TypePicker.SelectedIndex = (int)Star.Type;
            RightAscensionEntry.Text = Star.RightAscension.ToString();
            DeclinationEntry.Text = Star.Declination.ToString();
            AddButton.Text = Resource.Save;
        }


        Star Star { get; set; }


        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (NameEntry.Text == null || WeightEntry.Text == null || RadiusEntry.Text == null || TemperatureEntry.Text == null || LuminosityEntry.Text == null ||
                TypePicker.SelectedIndex == -1 || RightAscensionEntry.Text == null || DeclinationEntry == null) 
            {
                await DisplayAlert(Resource.Error, Resource.FieldsMustNotBeEmpty, Resource.OK);
                return;
            }
            if (!double.TryParse(WeightEntry.Text, out double weight))
            {
                await DisplayAlert(Resource.Error, Resource.WeightMustBeAPositiveNumber, Resource.OK);
                return;
            }
            if (!double.TryParse(RadiusEntry.Text, out double radius))
            {
                await DisplayAlert(Resource.Error, Resource.RadiusMustBeAPositiveNumber, Resource.OK);
                return;
            }
            if (!double.TryParse(TemperatureEntry.Text, out double temperature))
            {
                await DisplayAlert(Resource.Error, Resource.TemperatureMustBeAPositiveNumber, Resource.OK);
                return;
            }
            if (!double.TryParse(LuminosityEntry.Text, out double luminosity))
            {
                await DisplayAlert(Resource.Error, Resource.LuminosityMustBeAPositiveNumber, Resource.OK);
                return;
            }
            if (!double.TryParse(RightAscensionEntry.Text, out double rightAscension) || rightAscension >= 24 || rightAscension < 0 || rightAscension % 1 >= 60) 
            {
                await DisplayAlert(Resource.Error, Resource.RightAscensionMustBeAPositiveNumber, Resource.OK);
                return;
            }
            if (!double.TryParse(DeclinationEntry.Text, out double declination) || declination < -90 || declination > 90 || Math.Abs(declination % 1) >= 60)
            {
                await DisplayAlert(Resource.Error, Resource.DeclinationMustBeAPositiveNumber, Resource.OK);
                return;
            }
            if (Star != null)
            {
                bool result = await DisplayAlert(Resource.ConfirmAction, Resource.AreYouSureYouWantToReplaceTheData, Resource.Yes, Resource.No);
                if (!result)
                    return;
                Star.Name = NameEntry.Text;
                Star.Weight = weight;
                Star.Radius = radius;
                Star.Luminosity = luminosity;
                Star.Temperature = temperature;
                Star.Type = (TypeOfStar)TypePicker.SelectedIndex;
                Star.RightAscension = rightAscension;
                Star.Declination = declination;
                await DisplayAlert(Resource.Notification, Resource.TheDataWasSuccessfullyReplaced, Resource.OK);
            }
            else
            {
                Data.Stars.Add(new Star(NameEntry.Text, weight, radius, temperature, luminosity, (TypeOfStar)TypePicker.SelectedIndex, rightAscension, declination));
                await DisplayAlert(Resource.Notification, Resource.DataWasSuccessfullyAdded, Resource.OK);
            }
            await Navigation.PopModalAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e) => await Navigation.PopModalAsync();
    }
}