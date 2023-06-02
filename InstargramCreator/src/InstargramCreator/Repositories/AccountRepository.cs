using InstargramCreator.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace InstargramCreator.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Accounts accounts)
        {
      
            accounts.CreateDate= DateTime.Now;
            _dbContext.Accounts.Add(accounts);
            _dbContext.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var delete = _dbContext.Accounts.FirstOrDefault(x => x.Id == id);
            if (delete != null)
            {
                _dbContext.Accounts.Remove(delete);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            var accounts = _dbContext.Accounts;
            _dbContext.Accounts.RemoveRange(accounts);
            _dbContext.SaveChanges();
        }
        public void DeleteRange(List<Guid> deleteList)
        {
            foreach (var id in deleteList)
            {
                var delete = _dbContext.Accounts.FirstOrDefault(x => x.Id == id);
                if (delete != null)
                {
                    _dbContext.Accounts.Remove(delete);
                }
            }
            _dbContext.SaveChanges();
        }

        public Accounts GetAccountByName(string name)
        {
           return  _dbContext.Accounts.Where(s => s.UserName== name).FirstOrDefault();
        }

        public List<Accounts> GetAll()
        {
            return _dbContext.Accounts.ToList();
        }
        public Accounts GetById(Guid id)
        {
            return _dbContext.Accounts.FirstOrDefault(s => s.Id == id);
        }
        public void Update(Accounts account)
        {
            if (_dbContext.Entry(account).State == EntityState.Unchanged)
            {
                _dbContext.SaveChanges();
            }
            _dbContext.Accounts.Attach(account);
            _dbContext.Entry(account).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
