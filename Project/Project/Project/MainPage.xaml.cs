using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using Xamarin.Essentials;
using System.Threading;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TapGestureRecognizer PlanetTapGestureRecognizer1 = new TapGestureRecognizer();
            TapGestureRecognizer StarTapGestureRecognizer2 = new TapGestureRecognizer();
            TapGestureRecognizer ConstellationTapGestureRecognizer3 = new TapGestureRecognizer();
            PlanetTapGestureRecognizer1.Tapped += async (s, e) => await Navigation.PushAsync(new CatalogOfPlanetsPage());
            StarTapGestureRecognizer2.Tapped += async (s, e) => await Navigation.PushAsync(new CatalogOfStarsPage());
            ConstellationTapGestureRecognizer3.Tapped += async (s, e) => await Navigation.PushAsync(new CatalogOfConstellationsPage());

            PlanetImage.GestureRecognizers.Add(PlanetTapGestureRecognizer1);
            StarImage.GestureRecognizers.Add(StarTapGestureRecognizer2);
            ConstellationImage.GestureRecognizers.Add(ConstellationTapGestureRecognizer3);

            PlanetLabel.GestureRecognizers.Add(PlanetTapGestureRecognizer1);
            StarLabel.GestureRecognizers.Add(StarTapGestureRecognizer2);
            ConstellationLabel.GestureRecognizers.Add(ConstellationTapGestureRecognizer3);

            DisapearScreenSaver();
            
        }


        private async void DisapearScreenSaver()
        {
            await ScreenSaverImage.FadeTo(0, 5000, Easing.SpringIn);
            ScreenSaverImage.IsVisible = false;
        }


        private async void LanguageButton_Clicked(object sender, EventArgs e)
        {
            string language = await DisplayActionSheet("Язык приложения", "Отмена", null, "Английский", "Русский");
            if(language != "Отмена")
            {
                if (language == "Английский")
                    CultureInfo.CurrentUICulture = new CultureInfo("en");
                else
                    CultureInfo.CurrentUICulture = new CultureInfo("ru");
                PlanetLabel.Text = Resource.Planets;
                StarLabel.Text = Resource.Stars;
                ConstellationLabel.Text = Resource.Constellations;
                OpenWebPageButton.Text = Resource.InternetAccess;
                LanguageButton.Text = Resource.Language;
            }
        }

        private async void OpenWebPageButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new WebPage());
    }
}
