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
	public partial class CatalogOfPlanetsPage : ContentPage
	{
		public CatalogOfPlanetsPage ()
		{
			InitializeComponent ();

            Planets = Data.Planets.OrderBy(planet => planet.OrbitRadius).ToList();
            this.BindingContext = this;
		}

        public List<Planet> Planets { get; set; }

        private async void PlanetListView_ItemTapped(object sender, ItemTappedEventArgs e) => await Navigation.PushAsync(new InformationAboutThePlanetPage((Planet)e.Item));
        private async void GalleryOfPlanets_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new PhotosOfPlanetsPage());
        private async void OpenInteractivePageButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new InteractivePage());
    }
}