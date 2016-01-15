using System;
using System.Collections.Generic;
using System.Linq;
using LetsSolveIt.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.BLL
{
    public class SubmissionLogic
    {
        private readonly LetsSolveItContext _entities;

        public SubmissionLogic(LetsSolveItContext entities)
        {
            _entities = entities;
        }

        public List<Submissions> Get()
        {
            return _entities.Submissions.ToList();
        }

        public List<Submissions> GetForCampaign(int campaignId)
        {
            return _entities.Submissions.Where( x => x.Campaign.Id == campaignId).ToList();
        }

        public Submissions Get(int id)
        {
            return _entities.Submissions.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Submissions submission)
        {
            var exists = _entities.Submissions.FirstOrDefault(x => x.Id == submission.Id);

            if (exists == null)
            {
                submission.CreatedDate = DateTime.Now;
                submission.State = true;
                _entities.Submissions.Add(submission);
            }
            else
            {
                exists.Campaign = submission.Campaign;
                exists.Category = submission.Category;
                exists.InvitedUsers = submission.InvitedUsers;
                exists.LastModifiedDate = DateTime.Now;
                exists.Suggestion = submission.Suggestion;
                exists.User = submission.User;
                exists.Votes = submission.Votes;
            }
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var submission = _entities.Submissions.FirstOrDefault(x => x.Id == id);

            if (submission == null)
            {
                throw new ApplicationException("You are bad!");
            }

            submission.State = false;

            _entities.SaveChanges();
        }

        public void Delete(Submissions submission)
        {
            Delete(submission.Id);
        }

    }
}