using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.Serialization;

namespace Project
{
    [Serializable]
    public class Planet
    {
        private int _radius;
        private int _weight;
        private double _periodOfRotationAroundAxis;
        private int _periodOfRotationAroundTheBody;
        private int _orbitRadius;
        private string _hexColor;

        public Planet(string name)
        {
            Name = name;
        }
        public Planet(string name, int radius, int weight, double periodOfRotationAroundAxis, string theBodyAroundWhichThePlanetRotates, int periodOfRotationAroundTheBody, 
            int orbitRadius, string nameOfImage, string nameOfImage1, string hexColor)
        {
            Name = name;
            Radius = radius;
            Weight = weight;
            PeriodOfRotationAroundAxis = periodOfRotationAroundAxis;
            TheBodyAroundWhichThePlanetRotates = theBodyAroundWhichThePlanetRotates;
            PeriodOfRotationAroundTheBody = periodOfRotationAroundTheBody;
            OrbitRadius = orbitRadius;
            NameOfImage = "PhotosOfPlanets/" + nameOfImage + ".jpg";
            NameOfImage1 = "PhotosOfPlanets/" + nameOfImage1 + ".jpg";
            _hexColor = hexColor;
        }

        public string Name { get; set; }
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value > 0 ? value : throw new Exception();
            }
        }
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value > 0 ? value : throw new Exception();
            }
        }
        public double PeriodOfRotationAroundAxis
        {
            get
            {
                return _periodOfRotationAroundAxis;
            }
            set

            {
                _periodOfRotationAroundAxis = value > 0 ? value : throw new Exception();
            }
        }
        public string TheBodyAroundWhichThePlanetRotates { get; set; }
        public int PeriodOfRotationAroundTheBody
        {
            get
            {
                return _periodOfRotationAroundTheBody;
            }
            set

            {
                _periodOfRotationAroundTheBody = value > 0 ? value : throw new Exception();
            }
        }
        public int OrbitRadius
        {
            get
            {
                return _orbitRadius;
            }
            set

            {
                _orbitRadius = value > 0 ? value : throw new Exception();
            }
        }
        public string NameOfImage { get; set; }
        public string NameOfImage1 { get; set; }
        public Color PlanetColor
        {
            get
            {
                return Color.FromHex(_hexColor);
            }
        }

        public override string ToString() => Name;
    }
}
