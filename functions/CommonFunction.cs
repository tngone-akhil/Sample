using bugtracker.models;
using bugtracker.temporaryModels;
using bugtrackerapi.functions;

using MongoDB.Driver;

namespace bugtrackerapi.commonfunction;
public class CommonFunction
{


    public static void Login()
    {
        Console.WriteLine("enter the Login id");
         Console.WriteLine("enter the Login id");
        string? id = Console.ReadLine();
        Console.WriteLine("enter the password");
        
        string? password = Console.ReadLine();
        Login login = new Login(id, password);
        var dataBase = GetConnection();
        var usercollection = dataBase.GetCollection<Users>("users");
        var filter = Builders<Users>.Filter.Where(i => i.User_id == id && i.Password == password);
        Users user = usercollection.Find(filter).FirstOrDefault();
        if (user != null && user.role == Role.Admin)
        {
            AdminFunctions.Functions(login);
        }
        else if (user != null && user.role == Role.Developer)
        {
            if (user.isBlock)
            {
                Console.WriteLine("you are blocked");

            }
            else
            {
                DevelperFunction.Functions(login);
            }

        }
        else if (user != null && user.role == Role.QA)
        {
            if (user.isBlock)
            {
                Console.WriteLine("you are blocked");
            }
            else
            {
                QAfunctions.Functions(login);
            }

        }
        else if (user == null)
        {
            Console.WriteLine("enter valid credentials");
        }
        Login();
    }
    public static IMongoDatabase GetConnection()
    {
        string url = "mongodb+srv://Anagha:Sinless98@cluster0.mjbhkwl.mongodb.net/";
        var connection = new MongoClient(url);
        return connection.GetDatabase("BugTracker");

    }
}
