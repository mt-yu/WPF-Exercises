using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.ViewModels
{
    public class AboutViewModel : BindableBase
    {
        public AboutViewModel()
        {
            OpenLinkCommand = new DelegateCommand<string>(OpenLink);
        }

        private void OpenLink(string uri)
        {
            // 在这里处理打开链接的逻辑
            if (uri is not null && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(uri) { UseShellExecute = true });
            }
        }

        public DelegateCommand<string> OpenLinkCommand { get; private set; }
    }
}
