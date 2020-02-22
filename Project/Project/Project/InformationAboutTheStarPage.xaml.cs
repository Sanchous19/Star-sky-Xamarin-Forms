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
    public partial class InformationAboutTheStarPage : ContentPage
    {
        public InformationAboutTheStarPage(Star star)
        {
            InitializeComponent();

            Star = star;
            this.BindingContext = star;
            string[] typeOfStar = { "Коричневый карлик", "Белый карлик", "Красный гигант", "Переменная звезда", "Типа Вольфа — Райе", "Типа T Тельца",
                "Новая", "Сверхновая", "Гиперновая", "LBV", "ULX", "Нейтронная звезда", "Уникальная звезда" };
            TypeLabel.Text = typeOfStar[(int)star.Type];
        }


        public Star Star { get; set; }


        private async void RemoveStarButton_Clicked(object sender, EventArgs e)     // Удаление звезды на кнопку
        {
            bool result = await DisplayAlert(Resource.ConfirmAction, Resource.AreYouSureYouWantToRemoveTheStarFromTheCatalog, Resource.Yes, Resource.No);
            if (result)
            {
                Data.Stars.Remove(Star);
                Star.Constellation.Stars.Remove(Star);
                await DisplayAlert(Resource.Notification, Resource.TheStarHasBeenSuccessfullyRemovedFromTheCatalog, Resource.OK);
                await Navigation.PopAsync();
            }
        }
        private async void ChangeStarButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new AddingNewStarPage(Star));
    }
}