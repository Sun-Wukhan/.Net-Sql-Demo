using Microsoft.EntityFrameworkCore;
using Models;

namespace PersonDb
{
    public class PersonSqlite : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}

