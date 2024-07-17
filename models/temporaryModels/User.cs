using System.ComponentModel.DataAnnotations;
using bugtracker.models;

namespace bugtracker.temporaryModels;
public class User
{

    public string? user_name { get; set; }

    public string? password { get; set; }

    public string? email { get; set; }
    public Role role { get; set; }
    public Boolean isBlock { get; set; }
}