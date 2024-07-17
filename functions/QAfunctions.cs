using System.Text.Json;
using bugtracker.models;
using bugtracker.temporaryModels;
using bugtrackerapi.commonfunction;
using bugtrackerapi.models.Models;

namespace bugtrackerapi.functions;
public class QAfunctions
{
    public static string? content;

    public static void Functions(Login login)
    {

        while (true)
        {
            Console.WriteLine("press 1 to show Projects\npress 2 to EditBug\npress 3 to resolvebugs");
            Console.WriteLine("press 4 to edit profile\npress 5 to add bug\npress 6 to logout\npress 7 to show notifications");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowProject(login);
                    break;
                case "2":
                    EditBugs(login);
                    break;
                case "3":
                    UpdateBugs(login);
                    break;
                case "4":
                    EditProfile(login);
                    break;
                case "5":
                    AddBugs(login);
                    break;
                case "6":
                    CommonFunction.Login();
                    break;
                case "7":
                    ShowNotification(login);
                    break;
                default:
                    break;
            }
        }
    }

    private static async void ShowProject(Login login)
    {
        await Program.ProcessGet($"api/QA/ShowProjects/{login.userId}/{login.password}");
        List<Projects>? plist = JsonSerializer.Deserialize<List<Projects>>(content);
        foreach (Projects p in plist)
        {
            Console.WriteLine(p);
            Console.WriteLine();
        }
    }


    private static async void UpdateBugs(Login login)
    {

        Console.WriteLine("Enter the Bug id");
        long bugId = Convert.ToInt64(Console.ReadLine());
        await Program.ProcessPut($"api/QA/UpdateBugs/{login.userId}/{login.password}/{bugId}");
    }

    private static async void EditBugs(Login login)
    {
        BugEdit edit = new BugEdit();
        Console.WriteLine("Enter the Bug id");
        long bugId = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("enter the description");
        edit.description = Console.ReadLine();
        List<string> userIds = new List<string>();
        bool isTrue = true;
        do
        {
            Console.WriteLine("enter the userId");
            userIds.Add(Console.ReadLine());
            Console.WriteLine("enter any key to add more enter 0 to stop");
            string? num = Console.ReadLine();
            if (num == "0")
            {
                isTrue = false;
            }
        } while (isTrue);
        edit.employeeIds = userIds;
        await Program.ProcessPut($"api/QA/EditBug/{login.userId}/{login.password}/{bugId}", edit);
    }

    private static async void EditProfile(Login login)
    {
        EditProfile edit = new EditProfile();
        Console.WriteLine("Enter the new name");
        edit.name = Console.ReadLine();
        Console.WriteLine("Enter the new password");
        edit.password = Console.ReadLine();
        edit.user_id = login.userId;
        await Program.ProcessPut($"api/QA/Editprofile/{login.userId}/{login.password}", edit);
        CommonFunction.Login();
    }

    private static async void AddBugs(Login login)
    {
        BugCreation bug = new BugCreation();
        Console.WriteLine("enter the projectId");
        bug.projectId = Console.ReadLine();
        Console.WriteLine("enter the bug description");
        bug.description = Console.ReadLine();
        List<string> userIds = new List<string>();
        bool isTrue = true;
        do
        {
            Console.WriteLine("enter the userId");
            userIds.Add(Console.ReadLine());
            Console.WriteLine("enter any key to add more enter 0 to stop");
            string? num = Console.ReadLine();
            if (num == "0")
            {
                isTrue = false;
            }
        } while (isTrue);
        bug.employeeIds = userIds;
        await Program.ProcessPost($"api/QA/ReportBug/{login.userId}/{login.password}", bug);

    }
    private static async void ShowNotification(Login login)
    {
        await Program.ProcessGet($"api/QA/showNotification/{login.userId}/{login.password}");
        List<Notifications>? plist = JsonSerializer.Deserialize<List<Notifications>>(content);
        foreach (Notifications p in plist)
        {
            Console.WriteLine(p);
            Console.WriteLine();
        }
    }
}