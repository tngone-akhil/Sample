namespace bugtracker.models;
public class Status
{
    public string? _header{get;set;}
    public string? message{get;set;}
    public Boolean isCompleted{get;set;}

    public override string ToString()
    {
        return $"{message}";
    }
}