using System;
using System.Collections.Generic;
using System.Linq;
using LetsSolveIt.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.BLL
{
    public class CommentLogic
    {
        private readonly LetsSolveItContext _entities;

        public CommentLogic(LetsSolveItContext entities)
        {
            _entities = entities;
        }

        public List<Comments> Get()
        {
            return _entities.Comments.ToList();
        }

        public Comments Get(int id)
        {
            return _entities.Comments.FirstOrDefault(x => x.Id == id);
        }

        public List<Comments> GetForSubmission(int submissionId)
        {
            return _entities.Comments.Where(x => x.Submission.Id == submissionId).ToList();
        }

        public void Save(Comments comments)
        {
            var exists = _entities.Comments.FirstOrDefault(x => x.Id == comments.Id);

            if (exists == null)
            {
                comments.CreatedDate = DateTime.Now;
                comments.State = true;
                _entities.Comments.Add(comments);
            }
            else
            {
                exists.CommentText = comments.CommentText;
                exists.User = comments.User;
                exists.Votes = comments.Votes;
            }
            _entities.SaveChanges();
        }

        public void Delete(int commentId)
        {
            var comment = _entities.Comments.FirstOrDefault(x => x.Id == commentId);

            if (comment == null)
            {
                throw new ApplicationException("You are bad!");
            }

            comment.State = false;

            _entities.SaveChanges();
        }

        public void Delete(Comments comment)
        {
            Delete(comment.Id);
        }

    }
}