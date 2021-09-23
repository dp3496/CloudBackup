using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBackup.Library
{
    public partial class CloudBackupPage
    {
        public CloudBackupPage()
        {
            InitializeComponent();

            DataContext = new CloudBackupPageViewModel();
        }
    }
}
