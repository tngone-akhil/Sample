using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using MongoDB.Bson.Serialization.Attributes;

namespace bugtracker.models;
public class Users
{
    [BsonId]
    public string? User_id { get; set; }
    public string? User_name { get; set; }
    public string? Password { get; set; }
    public Role role { get; set; }
    public string? email { get; set; }
    public Boolean isBlock { get; set; }
    public List<string>? projectsIds { get; set; }
    public List<Notification>? notifications { get; set; }
    public List<long>? bugIds{get; set;}


}