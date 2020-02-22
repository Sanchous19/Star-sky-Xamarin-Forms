using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Project
{
    [Serializable]
    public static class Data
    {
        public static Collection<Constellation> Constellations { get; set; }
        public static Collection<Star> Stars { get; set; }
        public static Collection<Planet> Planets { get; set; }
        public static Collection<string> URLs { get; set; }

        static Data()
        {
            Stars = new Collection<Star>()
            {
                new Star("Виктория", 0.5, 0.3, 200000, 500000, TypeOfStar.Unique, 12, 90),
                new Star("Альферац", 3.6, 2.8, 13000, 200, TypeOfStar.LBV),             //
                new Star("2M1207", 0.025, 0.25, 2550, 0.015, TypeOfStar.BrownDwarf),
                new Star("Сириус", 2, 1.7, 9940, 25.4, TypeOfStar.WhiteDwarf),
                new Star("40 Эридана", 3.6, 2.8, 13000, 200, TypeOfStar.WhiteDwarf),
                new Star("Звезда ван Маанена", 0.7, 0.009, 4000, 0.000174, TypeOfStar.WhiteDwarf),
                new Star("Мю Цефея", 25, 1035, 2300, 350000, TypeOfStar.RedGiant),
                new Star("Солнце", 1, 1, 5778, 1, TypeOfStar.RedGiant),
                new Star("Бетельгейзе", 17, 1075, 3600, 70000, TypeOfStar.Variable),
                new Star("Полярная звезда", 6, 37.5, 7000, 2200, TypeOfStar.Variable),
                new Star("Денеб", 21, 210, 8550, 196000, TypeOfStar.Variable),
                new Star("Дельта Цефея", 4.5, 41.6, 6150, 1250, TypeOfStar.Variable),

                new Star("2", 23, 1, 2, 3, TypeOfStar.ULX, 2.4, -70.1),
                new Star("3", 3,  37.5, 6, 2200, TypeOfStar.LBV, 7, -20),
                new Star("4", 23, 37.5, 6, 2200, TypeOfStar.LBV, 15, -10),
                new Star("5", 32, 37.5, 6, 2200, TypeOfStar.LBV, 23, -50),
                new Star("6", 32, 37.5, 6, 2200, TypeOfStar.LBV)
            };
            Constellations = new Collection<Constellation>()
            {
                new Constellation("123", "https://v-kosmose.com/wp-content/uploads/2014/02/aries.jpg", new Collection<Star>{ Stars[0], Stars[1], Stars[2] }),
                new Constellation("32423", "asdfd", new Collection<Star>())
            };
            Planets = new Collection<Planet>()
            {
                new Planet("Меркурий", 2440, 33, 58.6, "Солнце", 88, 58, "mercury", "mercury1", "#747275"),
                new Planet("Венера", 6052, 490, 243, "Солнце", 225, 108, "venera", "venera1", "#cab48a"),
                new Planet("Земля", 6371, 600, 1, "Солнце", 365, 150, "earth", "earth1", "#0b265c"),
                new Planet("Марс", 3390, 64, 1.03, "Солнце", 687, 228, "mars", "mars1", "#9c3013"),
                new Planet("Юпитер", 69911, 190000, 0.41, "Солнце", 4380, 778, "jupiter", "jupiter1", "#9a7858"),
                new Planet("Сатурн", 58232, 57000, 0.45, "Солнце", 10585, 1429, "saturn", "saturn1", "#e0be9f"),
                new Planet("Уран", 25362, 8700, 0.72, "Солнце", 30660, 2871, "uran", "uran1", "#3edfe0"),
                new Planet("Нептун", 24622, 10000, 0.67, "Солнце", 60225, 4504, "neptun", "neptun1", "#0187e5")
            };
            URLs = new Collection<string>();
        }
    }
}
