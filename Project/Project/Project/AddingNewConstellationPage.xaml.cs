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
    public partial class AddingNewConstellationPage : ContentPage
    {
        public AddingNewConstellationPage()
        {
            InitializeComponent();

            Stars = new Collection<Star>();

            NamesOfStars = new Dictionary<string, int>();
            for (int i = 0, count = Data.Stars.Count; i < count; i++)
                if (Data.Stars[i].Constellation == null)
                {
                    Stars.Add(Data.Stars[i]);
                    NamesOfStars.Add(Data.Stars[i].Name, -1);
                }

            StarPicker picker = new StarPicker(NamesOfStars);
            picker.SelectedIndexChanged += StarPicker_SelectedIndexChanged;
            StackLayout stack = new StackLayout() { Orientation = StackOrientation.Horizontal };
            stack.Children.Add(picker);
            StarsStack.Children.Add(stack);
        }

        public AddingNewConstellationPage(Constellation constellation)
        {
            InitializeComponent();

            Constellation = constellation;
            Stars = new Collection<Star>();
            NamesOfStars = new Dictionary<string, int>();
            for (int i = 0, count = Data.Stars.Count; i < count; i++)
                if (Data.Stars[i].Constellation == null)
                    Stars.Add(Data.Stars[i]);
            for (int i = 0, count = Constellation.Stars.Count; i < count; i++)
                Stars.Add(Constellation.Stars[i]);

            for (int i = 0, count = Stars.Count; i < count; i++)
                NamesOfStars.Add(Stars[i].Name, -1);

            NameEntry.Text = Constellation.Name;
            ImageEntry.Text = Constellation.ImageOfConstellation;
            StarPicker picker = new StarPicker(NamesOfStars);
            StackLayout stack = new StackLayout() { Orientation = StackOrientation.Horizontal };
            stack.Children.Add(picker);
            StarsStack.Children.Add(stack);
            picker.SelectedIndexChanged += StarPicker_SelectedIndexChanged;

            for (int i = 0, count = Constellation.Stars.Count; i < count; i++)
            {
                picker = (StarPicker)((StackLayout)StarsStack.Children[i]).Children[0];
                picker.SelectedItem = Constellation.Stars[i].Name;
            }
            AddButton.Text = Resource.Save;
        }


        public Constellation Constellation { get; set; }
        public Collection<Star> Stars { get; set; }
        public Dictionary<string, int> NamesOfStars { get; set; }


        private class StarPicker : Picker
        {
            public StarPicker(Dictionary<string, int> nameOfStars)
            {
                RefreshItems(nameOfStars, -1);
                FontSize = 20;
            }

            public void RefreshItems(Dictionary<string, int> nameOfStars, int num)
            {
                Items.Clear();
                foreach (var name in nameOfStars)
                    if (name.Value == -1 || name.Value == num)
                    {
                        Items.Add(name.Key);
                    }
            }
        }


        private void StarPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string selectedItem = (string)((StarPicker)sender).SelectedItem;
            if (sender == ((StackLayout)StarsStack.Children[StarsStack.Children.Count - 1]).Children[0])
            {
                index = StarsStack.Children.Count - 1;
                NamesOfStars[selectedItem] = StarsStack.Children.Count - 1;
                Button button = new Button() { Text = "-", TextColor = Color.Black, CornerRadius = 30, FontSize = 20, BackgroundColor = Color.FromHex("#60757575"),
                    BorderColor = Color.Black, WidthRequest = 40 };
                button.Clicked += Button_Clicked;
                ((StackLayout)StarsStack.Children[StarsStack.Children.Count - 1]).Children.Add(button);
                StarPicker picker = new StarPicker(NamesOfStars);
                picker.SelectedIndexChanged += StarPicker_SelectedIndexChanged;
                StackLayout stack = new StackLayout() { Orientation = StackOrientation.Horizontal };
                stack.Children.Add(picker); 
                StarsStack.Children.Add(stack);
            }
            else
            {
                index = StarsStack.Children.IndexOf((View)((StarPicker)sender).Parent);
                string str = NamesOfStars.ElementAt(NamesOfStars.Values.ToList().IndexOf(index)).Key;
                NamesOfStars.Remove(str);
                NamesOfStars.Add(str, -1);
                NamesOfStars[selectedItem] = index;
            }
            for (int i = 0, count = StarsStack.Children.Count; i < count; i++)
            {
                if (i != index)
                {
                    StarPicker picker1 = ((StarPicker)((StackLayout)StarsStack.Children[i]).Children[0]);
                    picker1.SelectedIndexChanged -= StarPicker_SelectedIndexChanged;
                    string tempSelectedItem = (string)picker1.SelectedItem;
                    picker1.RefreshItems(NamesOfStars, i);
                    picker1.SelectedItem = tempSelectedItem;
                    picker1.SelectedIndexChanged += StarPicker_SelectedIndexChanged;
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string str = ((StarPicker)((StackLayout)(((Button)sender).Parent)).Children[0]).SelectedItem.ToString();
            NamesOfStars.Remove(str);
            NamesOfStars.Add(str, -1);
            int index = StarsStack.Children.IndexOf((View)((Button)sender).Parent);
            for (int i = 0, count = NamesOfStars.Count; i < count; i++) 
            {
                int value = NamesOfStars.ElementAt(i).Value;
                if (value > index)
                {
                    string key = NamesOfStars.ElementAt(i).Key;
                    value--;
                    NamesOfStars.Remove(key);
                    NamesOfStars.Add(key, value);
                }
            }
            StarsStack.Children.Remove((View)((Button)sender).Parent);
            for (int i = 0, count = StarsStack.Children.Count; i < count; i++)
            {
                StarPicker picker1 = (StarPicker)((StackLayout)StarsStack.Children[i]).Children[0];
                picker1.SelectedIndexChanged -= StarPicker_SelectedIndexChanged;
                string tempSelectedItem = (string)picker1.SelectedItem;
                picker1.RefreshItems(NamesOfStars, i);
                picker1.SelectedItem = tempSelectedItem;
                picker1.SelectedIndexChanged += StarPicker_SelectedIndexChanged;
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            bool isEntryRight = true;
            if (NameEntry.Text == null)
            {
                await DisplayAlert(Resource.Error, Resource.EnterTheNameOfConstellation, Resource.OK);
                isEntryRight = false;
            }
            if (isEntryRight)
            {
                string uri = ImageEntry.Text ?? "";
                Collection<Star> stars = new Collection<Star>();
                for (int i = 0, count = NamesOfStars.Count; i < count - 1; i++)
                    if (NamesOfStars.ElementAt(i).Value != -1)
                        stars.Add(Stars.ElementAt(i));

                if (Constellation != null)
                {
                    bool result = await DisplayAlert(Resource.ConfirmAction, Resource.AreYouSureYouWantToReplaceTheData, Resource.Yes, Resource.No);
                    if (!result)
                        return;
                    await DisplayAlert(Resource.Notification, Resource.TheDataWasSuccessfullyReplaced, Resource.OK);
                    Constellation.Name = NameEntry.Text;
                    Constellation.ImageOfConstellation = uri;
                    Constellation.Stars.Clear();
                    foreach (var s in stars)
                        Constellation.Stars.Add(s);
                    Constellation.DefinePosition();
                }
                else
                {
                    Data.Constellations.Add(new Constellation(NameEntry.Text, uri, stars));
                    await DisplayAlert(Resource.Notification, Resource.DataWasSuccessfullyAdded, Resource.OK);
                }
                await Navigation.PopModalAsync();
            }
        }

        private async void CancelButton_Clicked(object sender, EventArgs e) => await Navigation.PopModalAsync();
    }
}