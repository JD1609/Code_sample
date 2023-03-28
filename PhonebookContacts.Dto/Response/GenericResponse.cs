namespace PhonebookContacts.Dto.Response
{
    public class GenericResponse<T> : Response
    {
        public T? Data { get; set; }
    }
}
