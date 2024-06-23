using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Tito_Store.View;

namespace Tito_Store
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        

        //private async void Catigory_Clicked(object sender, EventArgs e)
        //{
        //    activityIndicator.IsRunning = true;
        //    activityIndicator.IsVisible = true;
        //    await Navigation.PushAsync(new Catigory());
        //    activityIndicator.IsRunning=false;
        //}

        //private async void Sales_Clicked(object sender, EventArgs e)
        //{
        //    activityIndicator.IsRunning = true;
        //    activityIndicator.IsVisible = true;
        //    await Navigation.PushAsync (new Sales());
        //    activityIndicator.IsRunning=false;
        //}

        //private async void Orders_Clicked(object sender, EventArgs e)
        //{
        //    activityIndicator.IsRunning = true;
        //    activityIndicator.IsVisible = true;
        //    await Navigation.PushAsync(new Orders());
        //    activityIndicator.IsRunning=false;
        //}

        //private async void Sotre_Clicked(object sender, EventArgs e)
        //{
        //    activityIndicator.IsRunning = true;
        //    activityIndicator.IsVisible = true;
        //    await Navigation.PushAsync(new Store());
        //    activityIndicator.IsRunning=false;
        //}

     
        //private async void outerMony_Clicked(object sender, EventArgs e)
        //{
        //    activityIndicator.IsRunning = true;
        //    activityIndicator.IsVisible = true;
        //    await Navigation.PushAsync(new outerMony());
        //    activityIndicator.IsRunning=false;
        //}

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            await Navigation.PushAsync(new Orders());
            activityIndicator.IsRunning = false;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            await Navigation.PushAsync(new Store());
            activityIndicator.IsRunning = false;
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            await Navigation.PushAsync(new Sales());
            activityIndicator.IsRunning = false;
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            await Navigation.PushAsync(new outerMony());
            activityIndicator.IsRunning = false;
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, TappedEventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            await Navigation.PushAsync(new returnes());
            activityIndicator.IsRunning = false;
        }
    }

}
