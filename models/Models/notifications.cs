namespace bugtrackerapi.models.Models
{
    public class Notifications
    {
        public string? header { get; set; }
        public string? message { get; set; }

        public override string ToString()
        {
            return $"---------------------------\n{header}\n{message}\n----------------------------";
        }
    }
}