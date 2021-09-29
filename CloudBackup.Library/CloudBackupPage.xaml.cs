using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace CloudBackup.Library
{
    public partial class CloudBackupPage
    {
        public CloudBackupPageViewModel ViewModel { get; set; }
        public CloudBackupPage()
        {
            InitializeComponent();

            ViewModel = new CloudBackupPageViewModel();
            DataContext = ViewModel;
        }

        public async void OnFloderChoose(object sender, RoutedEventArgs args)
        {
            var filePicker = new FileOpenPicker { SuggestedStartLocation = PickerLocationId.PicturesLibrary };

            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.FileTypeFilter.Add("*");

            var storageFile = await filePicker.PickSingleFileAsync();

            ViewModel.UploadToOneDrive(storageFile);
        }
    }
}
