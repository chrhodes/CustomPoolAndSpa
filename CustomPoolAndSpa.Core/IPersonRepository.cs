using Common.Domain;

namespace CustomPoolAndSpa.Core
{
    public interface IPersonRepository
    {
        int SavePerson(Person person);
    }
}
