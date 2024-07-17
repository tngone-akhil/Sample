namespace bugtracker.temporaryModels;

public class ProjectReport
{
    public string? projectId{get; set;}
    public string? projectName{get; set;}
    public DateOnly startDate{get; set;}
    public DateOnly endDate{get; set;}
    public long totalBugs{get; set;}
    public long bugsResolved{get; set;}
    public string? status{get; set;}

    public override string ToString()
    {
        return $"projectId = {projectId}\nprojectName = {projectName} \nstartDate = {startDate}\nendDate = {endDate}\nbugsResolved {bugsResolved}\nstatus = {status}";
    }
}