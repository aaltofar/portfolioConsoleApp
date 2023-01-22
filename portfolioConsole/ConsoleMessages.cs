using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace portfolioConsole;


public class Messages
{
    public static void TypeCmd()
    {
        Console.WriteLine();
        Console.WriteLine("Input a command and type enter.");

    }
    public static void CmdList()
    {
        Console.WriteLine();
        Console.WriteLine(@"Possible commands:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-[H]elp, prints out available commands");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("-[P]rojects, gives you a list of my projects I've done so far");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-[R]esume, a copy of my CV/resume");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-[L]inks and socials");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("-[C]lear terminal");
        Console.ResetColor();
    }
    public static void WelcomeMsg()
    {
        Console.WriteLine();
        Console.WriteLine("Hello and welcome to MAIP v0.9 (Marius Aalto's interactive portfolio)");
    }
    public static void TextLogo()
    {
        Console.WriteLine(@"
 __       __   ______   ______  _______                     ______       ______  
/  \     /  | /      \ /      |/       \                   /      \     /      \ 
$$  \   /$$ |/$$$$$$  |$$$$$$/ $$$$$$$  |       __     __ /$$$$$$  |   /$$$$$$  |
$$$  \ /$$$ |$$ |__$$ |  $$ |  $$ |__$$ |      /  \   /  |$$$  \$$ |   $$ \__$$ |
$$$$  /$$$$ |$$    $$ |  $$ |  $$    $$/       $$  \ /$$/ $$$$  $$ |   $$    $$ |
$$ $$ $$/$$ |$$$$$$$$ |  $$ |  $$$$$$$/         $$  /$$/  $$ $$ $$ |    $$$$$$$ |
$$ |$$$/ $$ |$$ |  $$ | _$$ |_ $$ |              $$ $$/   $$ \$$$$ |__ /  \__$$ |
$$ | $/  $$ |$$ |  $$ |/ $$   |$$ |               $$$/    $$   $$$//  |$$    $$/ 
$$/      $$/ $$/   $$/ $$$$$$/ $$/                 $/      $$$$$$/ $$/  $$$$$$/  

**********************************************************************************
Type [H] any time to show commands.");
    }

    internal static void CmdSwitch(IProjectService projectService)
    {
        var projectList = projectService.GetProjectInfo();

        TypeCmd();
        Console.Write("Command: ");
        var cmd = Console.ReadLine();
        switch (cmd.ToLower())
        {
            case "h":
                break;
            case "p":
                Console.WriteLine();
                Console.WriteLine("Here is a list of all my projects: ");
                foreach (var (project, i) in projectList.Select((p,i)=> (p,i)))
                {
                    Console.WriteLine($"[{i}] " + project.Name);
                }
                Console.WriteLine("To view any project, input a corresponding project number: ");
                string projCommandTxt = Console.ReadLine();
                bool projCommand = int.TryParse(projCommandTxt, out int projCommandnum);
                while (!projCommand)
                {
                    ErrorMsg();
                    Console.ReadLine();
                    projCommandTxt = Console.ReadLine();
                    projCommand = int.TryParse(projCommandTxt, out projCommandnum);
                }
                if (projCommand)
                {
                    projectList[projCommandnum].OpenBrowser();
                }
                break;
            case "r":
                break;
            case "l":
                break;
            case "c":
                break;
            default:
                Console.Clear();
                ErrorMsg();
                CmdList();
                break;
        }
    }

    private static void ErrorMsg()
    {
        Console.WriteLine("Command not recognized, try again.");
    }


}


