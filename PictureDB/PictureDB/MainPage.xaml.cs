using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PictureDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var cameraOptions = new StoreCameraMediaOptions();

            cameraOptions.PhotoSize = PhotoSize.Full;

            var photo =
               await Plugin.Media.CrossMedia.Current
                   .TakePhotoAsync(cameraOptions);
            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
                btnver.IsVisible = false;
                btnguardar.IsVisible = true;

                
            }
        }

        private void save_Clicked(object sender, EventArgs e)
        {

        }
    }
}
