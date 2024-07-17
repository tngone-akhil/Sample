using System.ComponentModel.DataAnnotations;
using bugtracker.models;

namespace bugtracker.temporaryModels;
public class Project
{

    public string? Project_Name { get; set; }

    public int startYear { get; set; }

    public int startMonth { get; set; }

    public int startDay { get; set; }

    public int endYear { get; set; }
    public int endMonth { get; set; }

    public int endDay { get; set; }
    public List<string>? user_Ids { get; set; }
}