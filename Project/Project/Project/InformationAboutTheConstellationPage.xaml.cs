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
	public partial class InformationAboutTheConstellationPage : ContentPage
	{
        public InformationAboutTheConstellationPage(Constellation constellation)
        {
            InitializeComponent();

            this.BindingContext = constellation;
            Constellation = constellation;
            try
            {
                ImageOfConstellation.Source = new UriImageSource { Uri = new Uri(constellation.ImageOfConstellation) };
            }
            catch(Exception)
            {
                ImageOfConstellation.Source = null;
                ImageOfConstellation.HeightRequest = 0;
            }
        }


        Constellation Constellation { get; set; }


        private async void StarsInConstellationListView_ItemTapped(object sender, ItemTappedEventArgs e) => await Navigation.PushAsync(new InformationAboutTheStarPage((Star)e.Item));
        private async void ChangeConstellationButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new AddingNewConstellationPage(Constellation));
        private async void RemoveConstellationButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert(Resource.ConfirmAction, Resource.AreYouSureYouWantToRemoveTheConstellationFromTheCatalog, Resource.Yes, Resource.No);
            if (result)
            {
                foreach (var star in Constellation.Stars)
                    star.Constellation = null;
                Data.Constellations.Remove(Constellation);
                await DisplayAlert(Resource.Notification, Resource.TheConstellationHasBeenSuccessfullyRemovedFromTheCatalog, Resource.OK);
                await Navigation.PopAsync();
            }
        }
    }
}