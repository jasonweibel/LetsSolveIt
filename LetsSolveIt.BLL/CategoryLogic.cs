using System;
using System.Collections.Generic;
using System.Linq;
using Ideas.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.BLL
{
    public class CategoryLogic
    {
        private readonly LetsSolveItContext _entities;

        public CategoryLogic(LetsSolveItContext entities)
        {
            _entities = entities;
        }

        public List<Categories> Get()
        {
            return _entities.Categories.ToList();
        }

        public Categories Get(int Id)
        {
            return _entities.Categories.FirstOrDefault(x => x.Id == Id);
        }

        public Categories Get(string category)
        {
            return _entities.Categories.FirstOrDefault(x => x.Category == category);
        }

        public void Save(Categories category)
        {
            var exists = _entities.Categories.FirstOrDefault(x => x.Id == category.Id);

            if (exists != null)
            {
                category.State = true;
                _entities.Categories.Add(category);
            }
            else
            {
                exists.Category = category.Category;
            }
            _entities.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            var category = _entities.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
            {
                throw new ApplicationException("You are bad!");
            }

            category.State = false;

            _entities.SaveChanges();
        }

        public void Delete(Categories category)
        {
            Delete(category.Id);
        }

    }
}