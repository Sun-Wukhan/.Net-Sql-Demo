using Microsoft.EntityFrameworkCore;
using Models;


namespace PersonDb;
public class PersonRepository : IPersonRepository
{
    private readonly PersonSqlite personSqlite;
    private List<Person> people;

    public PersonRepository(PersonSqlite personSqlite)
    {
        this.personSqlite = personSqlite;
    }


    public void SavePerson(Person person)
    {
        personSqlite.Add(person);
        personSqlite.SaveChanges();
    }
}

