using Microsoft.EntityFrameworkCore;
using PhonebookContacts.Data.Contact;

namespace PhonebookContacts.Server.Repositories
{
    public class DataContext : DbContext
    {
        public DbSet<ContactData> Contacts { get; set; }


        #region Ctor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion
    }
}
