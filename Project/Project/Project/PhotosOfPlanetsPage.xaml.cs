using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace Project
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotosOfPlanetsPage : CarouselPage
	{
		public PhotosOfPlanetsPage ()
		{
			InitializeComponent ();

            List<Planet> planets = Data.Planets.OrderBy(planet => planet.OrbitRadius).ToList();
            foreach (var planet in planets)
                Children.Add(AddNewContentPage(planet));
        }

        public ContentPage AddNewContentPage(Planet planet)
        {
            Image image = new Image { Source = planet.NameOfImage, HeightRequest = 600, WidthRequest = 600 };
            return new ContentPage()
            {
                BackgroundImage = "Images/starBackground.jpg",
                Content = new StackLayout
                {
                    Children = { image, new Label { Text = planet.Name, TextColor = planet.PlanetColor, FontSize=80, FontAttributes = FontAttributes.Bold,
                    HorizontalOptions = LayoutOptions.Center } }
                }
            };
        }
    }
}