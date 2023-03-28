namespace PhonebookContacts.Data.Response
{
    public class Response : IResponse
    {
        public string OperationGuid { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
