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
	public partial class StarSkyPage : ContentPage
	{
		public StarSkyPage ()
		{
			InitializeComponent ();
            foreach (var star in Data.Stars)
            {
                double x, y;
                
                if (star.Declination!=0)
                {
                    if (star.Declination > 0)
                    {
                        double angle = ((60 * (int)star.RightAscension + 100 * (star.RightAscension % 1)) / (24 * 60)) * 360;
                        double len = (60 * 90 - 60 * (int)star.Declination - 100 * (star.Declination % 1)) * (4.0 / 60.0);
                        x = 390 - len * Math.Sin(angle * Math.PI / 180);
                        y = 385 - len * Math.Cos(angle * Math.PI / 180);
                    }
                    else
                    {
                        double angle = ((60 * (int)star.RightAscension + 100 * (star.RightAscension % 1)) / (24 * 60)) * 360;
                        double len = (60 * 90 + 60 * (int)star.Declination + 100 * (star.Declination % 1)) * (4.0 / 60.0);
                        x = 1140 + len * Math.Sin(angle * Math.PI / 180);
                        y = 385 - len * Math.Cos(angle * Math.PI / 180);
                    }
                    Button showStarButton = new Button() { BackgroundColor = star.ColorOfStar, CornerRadius = 3,  };
                    showStarButton.Clicked += async (sender, e) =>
                    {
                        await Navigation.PushAsync(new InformationAboutTheStarPage(star));
                    };
                    StarSkyAbsLay.Children.Add(showStarButton, new Rectangle(x - 3, y - 3, 6, 6));
                    Label nameOfStarLabel = new Label { Text = star.Name, TextColor = star.ColorOfStar, FontSize = 10 };
                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (sender, e) =>
                    {
                        await Navigation.PushAsync(new InformationAboutTheStarPage(star));
                    };
                    nameOfStarLabel.GestureRecognizers.Add(tapGestureRecognizer);
                    StarSkyAbsLay.Children.Add(nameOfStarLabel, new Point(x + 5, y - 13));
                }
            }
        }
    }
}