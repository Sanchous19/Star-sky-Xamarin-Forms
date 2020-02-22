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
    public partial class WebPage : ContentPage
    {
        public WebPage()
        {
            InitializeComponent();
        }
        
        private void NewsWebView_Navigating(object sender, WebNavigatingEventArgs e) => URLSearchBar.Text = e.Url;
        private void GoBackButton_Clicked(object sender, EventArgs e) => NewsWebView.GoBack();
        private void URLSearchBar_SearchButtonPressed(object sender, EventArgs e) => NewsWebView.Source = URLSearchBar.Text;
        private void SaveURLButton_Clicked(object sender, EventArgs e) => Data.URLs.Add(URLSearchBar.Text);
        private async void SelectURLButton_Clicked(object sender, EventArgs e)
        {
            string[] urls = Data.URLs.ToArray();
            var openURL = await DisplayActionSheet(Resource.Open, Resource.Cancel, null, urls);
            if (openURL != Resource.Cancel)
                NewsWebView.Source = openURL;
        }
        private async void CorrectURLsButton_Clicked(object sender, EventArgs e)
        {
            string[] urls = Data.URLs.ToArray();
            var removeURL = await DisplayActionSheet(Resource.Delete, Resource.Cancel, Resource.DeleteEverything, urls);
            if(removeURL != Resource.Cancel)
            {
                if (removeURL == Resource.DeleteEverything)
                    Data.URLs.Clear();
                else
                    Data.URLs.Remove(removeURL);
            }
        }

    }
}