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

        private const string ClientId = "94759087-1deb-4be1-8699-3baf277c9d63";

        private const string Scope = "onedrive.readwrite";

        private IOneDriveClient _oneDriveClient;


        public async Task<IOneDriveClient> GetDriveClient()
        {
            if(_oneDriveClient != null)
            {
                return _oneDriveClient;
            }

            try
            {
                var msaAuthProvider = new MsaAuthenticationProvider(ClientId, RedirectUrl, new string[] { Scope, "wl.signin" });
                await msaAuthProvider.AuthenticateUserAsync();
                _oneDriveClient = new OneDriveClient(@"https://api.onedrive.com/v1.0", msaAuthProvider);
            }
            catch(Exception e)
            {

            }

            return _oneDriveClient;
        }
    }
}
