using System;
using System.IO;
using Xamarin.Forms;
namespace CamaraSampleNew
{
    public class CamaraSampleNewPageViewModel:ViewModelBase
    {

        public string base64ImageStr = "";
        //public string imagename;
		string imagesource;
		public string ImageSource
		{
			get { return imagesource; }
			set
			{
				if (imagesource != value)
				{
					imagesource = value;
					OnPropertyChanged("ImageSource");
				}
			}
		}
		string textinput;
		public string TextInput
		{
			get { return textinput; }
			set
			{
				if (textinput != value)
				{
					textinput = value;
					OnPropertyChanged("TextInput");
				}
			}
		}
		Command _takephotocommand;
		Command _chooseimagecommand;
		Command _choosevideocommand;
		Command _chooseaudiocommand;

		public Command TakePhotoCommand => _takephotocommand ?? (_takephotocommand = new Command(ExecuteTakePhotoCommand));
		public Command ChooseImageCommand => _chooseimagecommand ?? (_chooseimagecommand = new Command(ExecuteChooseImageCommand));
		public Command ChooseVideoCommand => _choosevideocommand ?? (_choosevideocommand = new Command(ExecuteChooseVideoCommand));
		public Command ChooseAudioCommand => _chooseaudiocommand ?? (_chooseaudiocommand = new Command(ExecuteChooseAudioCommand));


		//private string GenerateFilePath()
		//{
		//	return Path.Combine(MediaService.Instance.GetPublicDirectoryPath(), MediaService.Instance.GenerateUniqueFileName("jpg"));
		//}

		private async void ExecuteTakePhotoCommand()
		{
            
          }
		private async void ExecuteChooseImageCommand()
		{
			

		}
		private async void ExecuteChooseVideoCommand()
		{
			
		}
        private async void ExecuteChooseAudioCommand()
        {
            
        }
			public CamaraSampleNewPageViewModel()
        {
        }
    }
}
