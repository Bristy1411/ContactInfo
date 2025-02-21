using ContactInfo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContactInfo.Data
{
    public class ContactInfoDbContext : DbContext
    {
        public ContactInfoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        protected ContactInfoDbContext()
        {
        }

        
    }
}
