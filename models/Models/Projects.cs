using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace bugtracker.models;
public class Projects
{
    public string project_id{get;set;}
    public string? project_Name{get;set;}
    public DateOnly startDate{get;set;}
    public DateOnly endDate{get;set;}
    public Status? status{get;set;}
    public List<string> user_Ids{get;set;}
    public List<long>? bugs{get; set;}
    public Projects(string project_id,List<string> user_Ids)
    {
        this.project_id = project_id;
        this.user_Ids = user_Ids;
    }

    public override string ToString()
    {
        string? str = null;
       foreach(string s in user_Ids)
        {
            str = str + $"{s} " ;
        };
    return $"Project_id = {project_id}\nProject_Name = {project_Name}\nstartDate = {startDate}\nendDate = {endDate}\nstatus = {status}\nTeam = {str}";
    }
}