using Microsoft.OneDrive.Sdk;
using Microsoft.OneDrive.Sdk.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBackup.Library
{
    public class OneDriveApiConnect
    {
        private const string RedirectUrl = "https://login.live.com/oauth20_desktop.srf";

        private const string ClientId = "0144b957-ed5c-499d-bd03-091db622798e";

        private const string Scope = "onedrive.readwrite";


        public async void GetDriveClient()
        {
            var msaAuthProvider = new MsaAuthenticationProvider(ClientId, RedirectUrl, new string[] { Scope, "wl.signin" });
            await msaAuthProvider.AuthenticateUserAsync();
            var oneDriveClient = new OneDriveClient(@"https://api.onedrive.com/v1.0", msaAuthProvider);
        }
    }
}
