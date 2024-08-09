namespace CommonModel.Contracts;

public class Error
{
    public string Title { get; set; }

    public string Message { get; set; }
    
    public int StatusCode { get; set; }
}