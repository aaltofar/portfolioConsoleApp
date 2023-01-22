
using portfolioConsole;
using System.Diagnostics;
//dependency injection
//project service som egen klasse
var projectService = new ProjectService();


Messages.TextLogo();
Messages.WelcomeMsg();
Messages.CmdList();

while (true)
{
    Messages.CmdSwitch(projectService);
}
