using System;
using System.Collections.Generic;
using System.Linq;
using Ideas.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.BLL
{
    public class UserLogic
    {
        private readonly LetsSolveItContext _entities;

        public UserLogic(LetsSolveItContext entities)
        {
            _entities = entities;
        }

        public List<Users> Get()
        {
            return _entities.Users.ToList();
        }

        public Users Get(int Id)
        {
            return _entities.Users.FirstOrDefault(x => x.Id == Id);
        }

        public void Save(Users user)
        {
            var exists = _entities.Users.FirstOrDefault(x => x.Id == user.Id);

            if (exists != null)
            {
                user.CreatedDate = DateTime.Now;
                user.State = true;
                _entities.Users.Add(user);
            }
            else
            {
                exists.UserName = user.UserName;
            }
            _entities.SaveChanges();
        }

        public void Delete(int Id)
        {
            var user = _entities.Users.FirstOrDefault(x => x.Id == Id);

            if (user == null)
            {
                throw new ApplicationException("You are bad!");
            }

            user.State = false;

            _entities.SaveChanges();
        }

        public void Delete(Users user)
        {
            Delete(user.Id);
        }

    }
}