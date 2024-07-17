using System.Text.Json;
using bugtracker.models;
using bugtracker.temporaryModels;
using bugtrackerapi.commonfunction;
using bugtrackerapi.models.Models;

namespace bugtrackerapi.functions;
public class DevelperFunction
{
    public static string? content = null;
    public static void Functions(Login login)
    {

        while (true)
        {
            Console.WriteLine("press 1 to show Projects\npress 2 to showbugs\npress 3 to resolvebugs");
            Console.WriteLine("press 4 to edit profile\npress 5 to logout\npress 6 to show notifications");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowProject(login);
                    break;
                case "2":
                    ShowBugs(login);
                    break;
                case "3":
                    ResolveBugs(login);
                    break;
                case "4":
                    EditProfile(login);
                    break;
                case "5":
                    CommonFunction.Login();
                    break;
                case "6":
                    ShowNotification(login);
                    break;
                default:
                    break;
            }
        }
    }

    private static async void ShowProject(Login login)
    {

        await Program.ProcessGet($"api/Developer/ShowProjects/{login.userId}/{login.password}");
        List<Projects>? plist = JsonSerializer.Deserialize<List<Projects>>(content);
        foreach (Projects p in plist)
        {
            Console.WriteLine(p);
            Console.WriteLine();
        }

    }

    private static async void ShowBugs(Login login)
    {
        await Program.ProcessGet($"api/Developer/ShowBugs/{login.userId}/{login.password}");
        List<Bugs>? plist = JsonSerializer.Deserialize<List<Bugs>>(content);
        foreach (Bugs p in plist)
        {
            Console.WriteLine(p);
            Console.WriteLine();
        }
    }


    private static async void ResolveBugs(Login login)
    {

        Console.WriteLine("Enter the Bug id");
        long bugId = Convert.ToInt64(Console.ReadLine());
        await Program.ProcessPut($"api/Developer/ResolveBugs/{login.userId}/{login.password}/{bugId}");
    }

    private static async void EditProfile(Login login)
    {
        EditProfile edit = new EditProfile();
        Console.WriteLine("Enter the new name");
        edit.name = Console.ReadLine();
        Console.WriteLine("Enter the new password");
        edit.password = Console.ReadLine();
        edit.user_id = login.userId;
        await Program.ProcessPut($"api/Developer/Editprofile/{login.userId}/{login.password}", edit);
        CommonFunction.Login();
    }

    private static async void ShowNotification(Login login)
    {
        await Program.ProcessGet($"api/Developer/showNotification/{login.userId}/{login.password}");
        List<Notifications>? plist = JsonSerializer.Deserialize<List<Notifications>>(content);
        foreach (Notifications p in plist)
        {
            Console.WriteLine(p);
            Console.WriteLine();
        }
    }

}