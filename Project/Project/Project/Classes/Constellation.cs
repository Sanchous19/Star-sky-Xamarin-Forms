using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Project
{
    public class Constellation : INotifyPropertyChanged
    {
        private string _name;
        private string _imageOfConstellation;
        private Collection<Star> _stars;


        public Constellation(string name, string imageOfConstellation, Collection<Star> stars)
        {
            Name = name;
            ImageOfConstellation = imageOfConstellation;
            Stars = stars;
            DefinePosition();

        }
        public Constellation(string name)
        {
            Name = name;
            Stars = new Collection<Star>();
            foreach (var star in Stars)
                star.Constellation = this;
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
        public string ImageOfConstellation
        {
            get
            {
                return _imageOfConstellation;
            }
            set
            {
                _imageOfConstellation = value;
                OnPropertyChanged("ImageOfConstellation");
            }
        }
        public Collection<Star> Stars
        {
            get
            {
                return _stars;
            }
            set
            {
                _stars = value;
                OnPropertyChanged("Stars");
                DefinePosition();
                OnPropertyChanged("PositionInTheStarrySky");
            }
        }
        public string PositionInTheStarrySky { get; set; }


        public void DefinePosition()
        {
            PositionInTheStarrySky = "";
            foreach (var star in Stars)
            {
                star.Constellation = this;
                if (!star.Name.Contains("Звезда"))
                    PositionInTheStarrySky += "Звезда ";
                PositionInTheStarrySky += star.Name + " имеет координаты: прямое восхождение " + star.RightAscension.ToString().Replace(',', '.') + 
                    ", склонение " + star.Declination.ToString().Replace(',', '.') + '\n';
            }
            if (PositionInTheStarrySky.Length > 1)
                PositionInTheStarrySky.Remove(PositionInTheStarrySky.Length - 1);
            OnPropertyChanged("PositionInTheStarrySky");
        }
        public override string ToString() => Name;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}