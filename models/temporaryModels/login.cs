namespace bugtracker.temporaryModels;
public class Login
{
    public  string? userId;
    public string? password;

    public Login(string? userId, string? password)
    {
        this.userId = userId;
        this.password = password;
    }
}