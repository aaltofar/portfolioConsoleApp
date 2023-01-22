using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace portfolioConsole
{
    internal class ProjectModel
    {
        public string? Name { get; init; }
        public string? Link { get; init; }

      
        public void OpenBrowser()
        {
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "www.github.com" + Link,
                UseShellExecute = true
            };
            Process.Start(ps);
        }
    }
}
