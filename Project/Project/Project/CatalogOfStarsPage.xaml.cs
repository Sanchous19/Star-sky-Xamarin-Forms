using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace Project
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CatalogOfStarsPage : ContentPage
	{
		public CatalogOfStarsPage ()
		{
			InitializeComponent ();

            Stars = Data.Stars;
            this.BindingContext = this;
		}


        public Collection<Star> Stars { get; set; }


        private async void AddNewStar_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new AddingNewStarPage());
        private async void OpenStarsTableButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new TableOfStarsInformationPage());
        private async void OpenStarSkyButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new StarSkyPage());
        private async void StarListView_ItemTapped(object sender, ItemTappedEventArgs e) => await Navigation.PushAsync(new InformationAboutTheStarPage((Star)e.Item));
        private void StarsSearchBar_TextChanged(object sender, TextChangedEventArgs e) => StarListView.ItemsSource = Stars.Where(star => star.Name.ToLower().Contains(StarsSearchBar.Text.ToLower()));
    }
}