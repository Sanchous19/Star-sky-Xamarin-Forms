using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InteractivePage : ContentPage
    {
        public InteractivePage()
        {
            InitializeComponent();

            foreach (var pl in Data.Planets)
            {
                double orbitRadius = (350.0 / Data.Planets.Search(new Planet("Нептун")).OrbitRadius) * pl.OrbitRadius;
                double size = (70.0 / Data.Planets.Search(new Planet("Юпитер")).Radius) * pl.Radius;
                Image image = new Image
                {
                    Aspect = Aspect.AspectFit,
                    Source = pl.NameOfImage,
                    AnchorX = -orbitRadius / size,
                    AnchorY = 0.5
                };
                AbsLay.Children.Add(image, new Rectangle(765 + orbitRadius - size / 2, 365 - size / 2, size, size));
                images.Add(image);
            }

            
            for (int i = 0; i < images.Count; i++)
            {
                double angle = -(360.0 * Data.Planets.Search(new Planet("Меркурий")).PeriodOfRotationAroundTheBody) / Data.Planets[i].PeriodOfRotationAroundTheBody;
                angles.Add(angle);
            }

            Task.Run(Fun0);
            Task.Run(Fun1);
            Task.Run(Fun2);
            Task.Run(Fun3);
            Task.Run(Fun4);
            Task.Run(Fun5);
            Task.Run(Fun6);
            Task.Run(Fun7);
        }

        List<Image> images = new List<Image>();
        List<double> angles = new List<double>();
        

        public async Task Fun0()
        {
            while (true)
                await images[0].RelRotateTo(angles[0], 10000, Easing.Linear);
        }
        public async Task Fun1()
        {
            while (true)
                await images[1].RelRotateTo(angles[1], 10000, Easing.Linear);
        }
        public async Task Fun2()
        {
            while (true)
                await images[2].RelRotateTo(angles[2], 10000, Easing.Linear);
        }
        public async Task Fun3()
        {
            while (true)
                await images[3].RelRotateTo(angles[3], 10000, Easing.Linear);
        }
        public async Task Fun4()
        {
            while (true)
                await images[4].RelRotateTo(angles[4], 10000, Easing.Linear);
        }
        public async Task Fun5()
        {
            while (true)
                await images[5].RelRotateTo(angles[5], 10000, Easing.Linear);
        }
        public async Task Fun6()
        {
            while (true)
                await images[6].RelRotateTo(angles[6], 10000, Easing.Linear);
        }
        public async Task Fun7()
        {
            while (true)
                await images[7].RelRotateTo(angles[7], 10000, Easing.Linear);
        }
    }
}
