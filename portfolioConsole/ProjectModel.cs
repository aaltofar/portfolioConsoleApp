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
        public string Name { get; private set; }
        public string Link { get; private set; }

        public ProjectModel(string projName, string projLink)
        {
            Name = projName;
            Link = projLink;
        }
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
