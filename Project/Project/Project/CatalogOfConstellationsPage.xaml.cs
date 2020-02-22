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
	public partial class CatalogOfConstellationsPage : ContentPage
	{
		public CatalogOfConstellationsPage ()
		{
			InitializeComponent ();

            Constellations = Data.Constellations;
            this.BindingContext = this;
		}


        public Collection<Constellation> Constellations { get; set; }
        
        private async void ConstellationListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new InformationAboutTheConstellationPage((Constellation)e.Item));
        }

        private async void AddNewConstellation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddingNewConstellationPage());
        }

        private void ConstellationSearchBar_TextChanged(object sender, TextChangedEventArgs e) => ConstellationListView.ItemsSource = Constellations.Where(constellation => constellation.Name.ToLower().Contains(ConstellationSearchBar.Text.ToLower()));
    }
}