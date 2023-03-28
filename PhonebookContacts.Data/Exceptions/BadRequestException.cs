namespace PhonebookContacts.Data.Exceptions
{
    public class BadRequestException : Exception
    {
        #region Ctor
        public BadRequestException(string message = "") : base(message)
        {
        }
        #endregion
    }
}
