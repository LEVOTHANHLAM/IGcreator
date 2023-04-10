using InstargramCreator.Entities;

namespace InstargramCreator.Repositories
{
    public interface IAccountRepository
    {
        void Add(Accounts accounts);
        List<Accounts> GetAll();
        void Update(Accounts accounts);
        Accounts GetById(Guid id);
        void Delete(Guid id);
        void DeleteRange(List<Guid> deleteList);
        void DeleteAll();
    }
}