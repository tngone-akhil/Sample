namespace bugtracker.temporaryModels;
public class Response
{
    public Boolean isTrue { get; set; }
    public string? Message { get; set; }

    public Response()
    {

    }
    public Response(Boolean isTrue, string? Message)
    {
        this.isTrue = isTrue;
        this.Message = Message;
    }
}