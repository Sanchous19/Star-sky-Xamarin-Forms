using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;

namespace Project
{
    public enum TypeOfStar { BrownDwarf, WhiteDwarf, RedGiant, Variable, WolfRayet, TTaurus, New, Supernovas, Hypernova, LBV, ULX, Neutron, Unique }


    public class Star : INotifyPropertyChanged
    {
        private string _name;
        private double _radius;
        private double _weight;
        private double _luminosity;
        private double _temperature;
        private TypeOfStar _type;
        private readonly string[] _typeOfStar = { "Коричневый карлик", "Белый карлик", "Красный гигант", "Переменная звезда", "Типа Вольфа — Райе",
            "Типа T Тельца", "Новая", "Сверхновая", "Гиперновая", "LBV", "ULX", "Нейтронная звезда", "Уникальная звезда" };
        private double _rightAscension;
        private double _declination;
        private Color _colorOfStar;


        public Star(string name) => Name = name;
        public Star(string name, double weight, double radius, double temperature,  double luminosity, TypeOfStar type) : this(name)
        {
            Weight = weight;
            Radius = radius;
            Temperature = temperature;
            Luminosity = luminosity;
            Type = type;
            StringType = _typeOfStar[(int)Type];
        }
        public Star(string name, double weight, double radius, double temperature, double luminosity, TypeOfStar type, double rightAscension, double declination) : this(name)
        {
            Weight = weight;
            Radius = radius;
            Temperature = temperature;
            Luminosity = luminosity;
            Type = type;
            StringType = _typeOfStar[(int)Type];
            RightAscension = rightAscension;
            Declination = declination;
            DefineColorOfStar();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value > 0 ? value : throw new Exception();
                OnPropertyChanged("Radius");
            }
        }
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value > 0 ? value : throw new Exception();
                OnPropertyChanged("Weight");
            }
        }
        public double Luminosity
        {
            get
            {
                return _luminosity;
            }
            set
            {
                _luminosity = value > 0 ? value : throw new Exception();
                OnPropertyChanged("Luminosity");
            }
        }
        public double Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value > 0 ? value : throw new Exception();
                OnPropertyChanged("Temperature");
                DefineColorOfStar();
                OnPropertyChanged("ColorOfStar");
            }
        }
        public TypeOfStar Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
                StringType = _typeOfStar[(int)Type];
                OnPropertyChanged("StringType");
            }
        }
        public string StringType { get; set; }
        public double RightAscension
        {
            get
            {
                return _rightAscension;
            }
            set
            {
                _rightAscension = value;
                OnPropertyChanged("RightAscension");
            }
        }
        public double Declination
        {
            get
            {
                return _declination;
            }
            set
            {
                _declination = value;
                OnPropertyChanged("Declination");
            }
        }
        public Constellation Constellation { get; set; }
        public Color ColorOfStar
        {
            get
            {
                return _colorOfStar;
            }
        }


        public override string ToString() => Name;
        public void DefineColorOfStar()
        {
            if (Temperature > 30000)
                _colorOfStar = Color.FromHex("#abc1ff");
            else if (Temperature > 10000)
                _colorOfStar = Color.FromHex("#cbd8ff");
            else if (Temperature > 6000)
                _colorOfStar = Color.White;
            else if (Temperature > 5000)
                _colorOfStar = Color.FromHex("#fff3a2");
            else if (Temperature > 3500)
                _colorOfStar = Color.FromHex("#ffe56f");
            else
                _colorOfStar = Color.FromHex("#ffa13e");
        }


    public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
