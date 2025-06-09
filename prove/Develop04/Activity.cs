public class Activity
{
    private string _name;
    private string _beginningMessage;
    private string _endMessage;
    private string _description;

    public Activity(string name, string beginningMessage, string endMessage, string description)
    {
        _name = name;
        _beginningMessage = beginningMessage;
        _endMessage = endMessage;
        _description = description;
    }
}
