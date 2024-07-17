using MongoDB.Bson.Serialization.Attributes;

namespace bugtracker.models;
public class Bugs
{
    
    public long id{get;set;}
    public string? description{get;set;}
    public  List<string>? employeeIds{get;set;}
    public string? projectId{get;set;}
    public Boolean isActive{get;set;}
    public Boolean isApproved{get; set;}

    public override string ToString()
    {
        return $"Bug id = {id}\ndescription = {description}\nprojectId = {projectId}\nisActive = {isActive}\nisApproved= {isApproved}";
    }
}