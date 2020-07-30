using Bills.Domain.Account.Entities;
using Bills.Domain.Account.Queries;
using Bills.Domain.Account.Repositories;
using Bills.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bills.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string userName)
        {
            return _context.User.AsNoTracking().SingleOrDefault(UserQueries.UserNameExists(userName));
        }

        public User GetUserById(Guid id)
        {
            return _context.User.AsNoTracking().FirstOrDefault(UserQueries.GetUserById(id));
        }

        public void Register(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var entity = _context.User.Find(UserQueries.GetUserById(id));
            _context.User.Remove(entity);
            _context.SaveChanges();   
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool UserNameExists(string userName)
        {
            return _context.User.AsNoTracking().Any(UserQueries.UserNameExists(userName));
        }

    }
}
