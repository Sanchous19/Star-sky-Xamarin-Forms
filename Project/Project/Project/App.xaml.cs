using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Globalization;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CultureInfo.CurrentUICulture = new CultureInfo(Preferences.Get("Language", "ru"));
            MainPage = new NavigationPage(new MainPage())
            {
                BarTextColor = Color.Black,
                BarBackgroundColor = Color.FromHex("#0e0e10")
            };
        }

        private string PlanetsFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Planets.dat");
        private string StarsFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Stars.dat");
        private string ConstellationsFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Constellations.dat");

        protected override void OnStart()
        {
            // Handle when your app starts
            //var formatter = new BinaryFormatter();
            //using (Stream stream = File.OpenRead(PlanetsFileName))
            //    Data.Planets = (Collection<Planet>)formatter.Deserialize(stream);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            var formatter = new BinaryFormatter();
            using (Stream stream = File.Create(PlanetsFileName))
                formatter.Serialize(stream, Data.Planets);

            Preferences.Set("Language", CultureInfo.CurrentUICulture.Name);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
