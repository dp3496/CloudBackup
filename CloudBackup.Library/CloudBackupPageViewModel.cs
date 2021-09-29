using CloudBackup.Library.Util;
using Microsoft.OneDrive.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.Storage;

namespace CloudBackup.Library
{
    public class CloudBackupPageViewModel
    {
        private readonly OneDriveApiConnect _oneDriveApiConnect;

        public CloudBackupPageViewModel()
        {
            _oneDriveApiConnect = new OneDriveApiConnect();
            AutoBackupCommand = new CommandViewModel(obj => true, Execute);
        }
        public IList<string> BackupOptions { get; set; } = new List<string>
        {
            "Google",
            "DropBox"
        };

        public ICommand AutoBackupCommand { get; set; }

        private async void Execute(object parameter)
        {
            await _oneDriveApiConnect.GetDriveClient();
        }

        public async void UploadToOneDrive(StorageFile storageFile)
        {
            var randomAccessStream = await storageFile.OpenReadAsync();
            using (var stream = await randomAccessStream.ConvertToStream())
            {
                var client = await _oneDriveApiConnect.GetDriveClient();
                await client.Drive.Root.ItemWithPath(storageFile.Name).Content.Request().PutAsync<Item>(stream);
            }
        }
    }
}
