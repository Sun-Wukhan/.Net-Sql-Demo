using Models;

namespace PersonDb
{
    public interface IPersonRepository
    {
        void SavePerson(Person person);
    }
}