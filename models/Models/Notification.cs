using MongoDB.Bson.Serialization.Attributes;

namespace bugtracker.models;
public class Notification
{
    public string? Header{get;set;}
    public string? Message{get;set;}

   
}