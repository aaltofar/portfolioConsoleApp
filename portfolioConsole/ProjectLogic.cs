using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace portfolioConsole;

internal class ProjectLogic
{

    public static List<ProjectModel> ProjectList = new List<ProjectModel>();

    public static void GetProjectInfo()
    {
        var html = @"https://github.com/aaltofar?tab=stars";

        HtmlWeb web = new HtmlWeb();

        var htmlDoc = web.Load(html);

        var node = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"user-starred-repos\"]/div/div/div/div/h3");

        foreach (var nNode in node.Elements())
        {
            //Console.WriteLine($"Node name: {node.Name} NodeType: {node.NodeType} Inner text: {node.InnerText}");
            if (nNode.NodeType == HtmlNodeType.Element)
            {
                string linkRaw = nNode.OuterHtml;
                var linkSplit = linkRaw.Split('"');
                string projectLink = linkSplit[1];
                var str = nNode.WriteContentTo();
                var newStr = str.Split('>').ToArray();
                var projectName = newStr[2];
                ProjectList.Add(MakeProject(projectName, projectLink));
            }
        }
    }

    public static ProjectModel MakeProject(string name, string link)
    {
        var newProject = new ProjectModel(projName: name, projLink: link);
        return newProject;
    }
}

