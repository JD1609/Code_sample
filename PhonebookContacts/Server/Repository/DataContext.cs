using Microsoft.EntityFrameworkCore;

namespace PhonebookContacts.Server.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
