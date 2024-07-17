using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text.Json;
using bugtracker.models;
using bugtracker.temporaryModels;
using bugtrackerapi.commonfunction;


namespace bugtrackerapi.functions;
public class AdminFunctions
{
    public static string? content;
    public static async void Functions(Login login)
    {

        while (true)
        {
            Console.WriteLine("press 1 to Create user\npress 2 to create Project\npress 3 to get projectstatus\npress 4 to lock user");
            Console.WriteLine("press 5 to edit profile\npress 6 to getuserReport\npress 7 to get add new employee to the project\npress 8 to logout");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    createUser(login);
                    break;
                case "2":
                    CreateProject(login);
                    break;
                case "3":
                    getProjectStatus(login);
                    break;
                case "4":
                    LockUser(login);
                    break;
                case "5":
                    editProfileDetails(login);
                    break;
                case "6":
                    getUserReport(login);
                    break;
                case "7":
                    AddEmployeToProject(login);
                    break;
                case "8":
                    CommonFunction.Login();
                    break;
                default:
                    break;
            }
        }
    }

    private static async void createUser(Login login)
    {
        User u = new User();
        Console.WriteLine("Enter the name");
        u.user_name = Console.ReadLine();
        Console.WriteLine("Enter the email");
        u.email = Console.ReadLine();
        Console.WriteLine("Enter the password");
        u.password = Console.ReadLine();
        u.isBlock = false;
        Console.WriteLine("Enter the user type 0 for admin ,1 for QA,2 for developer");
        u.role = (Role)Convert.ToInt32(Console.ReadLine());
        await Program.ProcessPost($"api/admin/CreateUser/{login.userId}/{login.password}", u);

    }

    private static async void AddEmployeToProject(Login login)
    {
        Console.WriteLine("enter the projectId");
        string? proId = Console.ReadLine();
        Console.WriteLine("enter the employee id to add");
        string? empId = Console.ReadLine();
        await Program.ProcessPut($"api/admin/AddNewEmployeesToProject/{login.userId}/{login.password}?employeId={empId}&projectId={proId}");
    }

    private static async void editProfileDetails(Login login)
    {
        EditProfile edit = new EditProfile();
        Console.WriteLine("Enter the new name");
        edit.name = Console.ReadLine();
        Console.WriteLine("Enter the new password");
        edit.password = Console.ReadLine();
        edit.user_id = login.userId;
        await Program.ProcessPut($"api/admin/Editprofile/{login.userId}/{login.password}", edit);
        CommonFunction.Login();
    }

    private static async void getProjectStatus(Login login)
    {
        await Program.ProcessGet($"/api/admin/GetProjectReport/{login.userId}/{login.password}");
        List<ProjectReport>? plist = JsonSerializer.Deserialize<List<ProjectReport>>(content);
        foreach (ProjectReport p in plist)
        {
            Console.WriteLine(p);
            Console.WriteLine();
        }

    }

    private static async void getUserReport(Login login)
    {
        Console.WriteLine("enter the UserId");
        string? id = Console.ReadLine();
        await Program.ProcessGet($"/api/admin/userReport/{login.userId}/{login.password}/{id}");
        Console.WriteLine(content);

    }

    private static async void LockUser(Login login)
    {
        Console.WriteLine("enter the UserId");
        string? id = Console.ReadLine();
        await Program.ProcessPut($"/api/admin/LockUser/{login.userId}/{login.password}/{id}");
    }


    private static async void CreateProject(Login login)
    {
        Project proj = new Project();
        Console.WriteLine("Enter the project name");
        proj.Project_Name = Console.ReadLine();
        Console.WriteLine("Enter the start Year");
        proj.startYear = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the start month");
        proj.startMonth = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the start day");
        proj.startDay = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the end Year");
        proj.endYear = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the end month");
        proj.endMonth = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the end day");
        proj.endDay = Convert.ToInt32(Console.ReadLine());
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
        proj.user_Ids = userIds;
        await Program.ProcessPost($"api/admin/CreateProject/{login.userId}/{login.password}", proj);
    }


}