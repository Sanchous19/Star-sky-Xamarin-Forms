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
	public partial class InformationAboutThePlanetPage : ContentPage
	{
		public InformationAboutThePlanetPage (Planet planet)
        {
            InitializeComponent ();
            this.BindingContext = planet;
        }
	}
}