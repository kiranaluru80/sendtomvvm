using System;
using System.IO;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


namespace CamaraSampleNew
{
    public partial class CamaraSampleNewPage : ContentPage
    {
        CamaraSampleNewPageViewModel vm;
        public CamaraSampleNewPage()
        {
            InitializeComponent();
             vm = new CamaraSampleNewPageViewModel();
            this.BindingContext = vm;
            MessagingCenter.Subscribe<CamaraSampleNewPageViewModel>(this, "Error1", (sender) =>
            {
                DisplayAlert("Error", "Error Message 1", "OK");
            });

            MessagingCenter.Subscribe<CamaraSampleNewPageViewModel>(this, "Sucess", (sender) =>
            {
                DisplayAlert("Error", "you are success", "OK");
            });
        }

        //private string GenerateFilePath()
        //{
        //	return Path.Combine(MediaService.Instance.GetPublicDirectoryPath(), MediaService.Instance.GenerateUniqueFileName("jpg"));
        //}

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            image.Source = ImageSource.FromStream(() =>
            {
                var streamOne = file.GetStream();
                //file.Dispose();
                return streamOne;
            });

            //var stream = file.GetStream();
            //var bytes = new byte[stream.Length];
            //await stream.ReadAsync(bytes, 0, (int)stream.Length);
            //string base64 = System.Convert.ToBase64String(bytes);


            using (var memoryStream = new System.IO.MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
				//var stfile.Path
                String[] obj = file.Path.Split('/');
				string ImageName = obj[obj.Length - 1];
                // file.Dispose();
                byte[] ImageBytes = memoryStream.ToArray();
                string base64String = System.Convert.ToBase64String(ImageBytes);
                vm.base64ImageStr = base64String;
                vm.TextInput = ImageName;
            }
        }

        private async void ChooseImage_Clicked(object sender, EventArgs e)
        {

        }



        private async void ChooseVideo_Clicked(object sender, EventArgs e)
        {
            
        }


        private async void ChooseAudio_Clicked(object sender, EventArgs e)
        {

        }

        private async void ResizeImage_Clicked(object sender, EventArgs e)
        {

        }
    }
}


