using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TableOfStarsInformationPage : ContentPage
	{
        private string _upArrowPath = "Images/UpArrow.jpg";
        private string _downArrowPath = "Images/downArrow.jpg";
        private string _leftArrowPath = "Images/leftArrow.jpg";


        public TableOfStarsInformationPage ()
		{
			InitializeComponent ();

            FillGrid();

            TapGestureRecognizer sortTapGestureRecognizer = new TapGestureRecognizer();
            sortTapGestureRecognizer.Tapped += SortTapGestureRecognizer_Tapped;
            StL1.GestureRecognizers.Add(sortTapGestureRecognizer);
            StL2.GestureRecognizers.Add(sortTapGestureRecognizer);
            StL3.GestureRecognizers.Add(sortTapGestureRecognizer);
            StL4.GestureRecognizers.Add(sortTapGestureRecognizer);
            StL5.GestureRecognizers.Add(sortTapGestureRecognizer);
            StL6.GestureRecognizers.Add(sortTapGestureRecognizer);
            
        }


        List<Star> Stars = Data.Stars.ToList();
        
        
        public void FillGrid()      // Заполнять таблицу 
        {
            TapGestureRecognizer showStarTapGestureRecognizer = new TapGestureRecognizer();
            showStarTapGestureRecognizer.Tapped += ShowStarTapGestureRecognizer_Tapped;
            for (int i = 5; i < StarsGrid.Children.Count; i++)   ////////////
                StarsGrid.Children[i].ClearValue(Label.TextProperty);
            for (int i = 1; i < StarsGrid.RowDefinitions.Count; i++)
                StarsGrid.RowDefinitions.RemoveAt(i);
            int size = 25;
            for (int i = 0; i < Stars.Count; i++)
            {
                Label label = new Label() { Text = Stars[i].ToString(), TextColor = Stars[i].ColorOfStar, FontSize = size };
                label.GestureRecognizers.Add(showStarTapGestureRecognizer);
                StarsGrid.RowDefinitions.Add(new RowDefinition());
                StarsGrid.Children.Add(label, 0, i + 1);
                StarsGrid.Children.Add(new Label { Text = Stars[i].Weight.ToString(), TextColor = Stars[i].ColorOfStar, FontSize = size }, 1, i + 1);
                StarsGrid.Children.Add(new Label { Text = Stars[i].Radius.ToString(), TextColor = Stars[i].ColorOfStar, FontSize = size }, 2, i + 1);
                StarsGrid.Children.Add(new Label { Text = Stars[i].Temperature.ToString(), TextColor = Stars[i].ColorOfStar, FontSize = size }, 3, i + 1);
                StarsGrid.Children.Add(new Label { Text = Stars[i].Luminosity.ToString(), TextColor = Stars[i].ColorOfStar, FontSize = size }, 4, i + 1);
                StarsGrid.Children.Add(new Label { Text = Stars[i].StringType, TextColor = Stars[i].ColorOfStar, FontSize = size }, 5, i + 1);
            }
        }
        private void SortTapGestureRecognizer_Tapped(object sender, EventArgs e)    // Отсортировывать при нажатии
        {
            StackLayout stackLayout = (StackLayout)sender;
            string startPath = ((Image)stackLayout.Children[1]).Source.ToString().Substring(6);
            ((Image)StL1.Children[1]).Source = _leftArrowPath;
            ((Image)StL2.Children[1]).Source = _leftArrowPath;
            ((Image)StL3.Children[1]).Source = _leftArrowPath;
            ((Image)StL4.Children[1]).Source = _leftArrowPath;
            ((Image)StL5.Children[1]).Source = _leftArrowPath;
            ((Image)StL6.Children[1]).Source = _leftArrowPath;

            if (stackLayout == StL1)
            {
                Stars = Data.Stars.OrderBy(star => star.Name).ToList();
                Stars.Reverse();
            }
            else if (stackLayout == StL2)
                Stars = Data.Stars.OrderBy(star => star.Weight).ToList();
            else if (stackLayout == StL3)
                Stars = Data.Stars.OrderBy(star => star.Radius).ToList();
            else if (stackLayout == StL4)
                Stars = Data.Stars.OrderBy(star => star.Temperature).ToList();
            else if (stackLayout == StL5)
                Stars = Data.Stars.OrderBy(star => star.Luminosity).ToList();
            else if (stackLayout == StL6)
            {
                Stars = Data.Stars.OrderBy(star => star.StringType).ToList();
                Stars.Reverse();
            }

            if (string.Compare(startPath, _downArrowPath) == 0)
                ((Image)stackLayout.Children[1]).Source = _upArrowPath;
            else
            {
                ((Image)stackLayout.Children[1]).Source = _downArrowPath;
                Stars.Reverse();
            }
            FillGrid();
        }
        private async void ShowStarTapGestureRecognizer_Tapped(object sender, EventArgs e)      // Посмотреть выбранную звезду
        {
            Star star = Data.Stars.Search(new Star(((Label)sender).Text));
            await Navigation.PushAsync(new InformationAboutTheStarPage(star));
        }
    }
}