using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace portfolioConsole;
internal interface IProjectService
{
    List<ProjectModel> GetProjectInfo();
}
internal class ProjectService : IProjectService
{
   

    public List<ProjectModel> GetProjectInfo()
    {
        var result = new List<ProjectModel>();

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

                result.Add(new ProjectModel() 
                { 
                    Link = projectLink,
                    Name = projectName
                });
            }
        }
        return result;
    }

    //public static ProjectModel MakeProject(string name, string link)
    //{
    //    var newProject = new ProjectModel(projLink: link, projName: name);
    //    return newProject;
    //}
}

