namespace PhonebookContacts.Data.Response
{
    public interface IResponse
    {
        string OperationGuid { get; set; }
        string Message { get; set; }
    }
}
