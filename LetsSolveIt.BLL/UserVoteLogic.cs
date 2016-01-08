using System;
using System.Collections.Generic;
using System.Linq;
using Ideas.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.BLL
{
    public class UserVoteLogic
    {
        private readonly LetsSolveItContext _entities;

        public UserVoteLogic(LetsSolveItContext entities)
        {
            _entities = entities;
        }

        public List<UserVotes> Get()
        {
            return _entities.UserVotes.ToList();
        }

        public UserVotes Get(int id)
        {
            return _entities.UserVotes.FirstOrDefault(x => x.Id == id);
        }

        public List<UserVotes> GetForCampaign(int id)
        {
            var submissions = _entities.Submissions.Where(x => x.Campaign.Id == id);
            var submissionIds = submissions.Select(x => id).Distinct();
            return _entities.UserVotes.Where(x => submissionIds.Contains(x.Submission.Id)).ToList();
        }

        public int GetCountForCampaign(int id)
        {
            var votes = GetForCampaign(id);
            return votes.Count();
        }

        public List<UserVotes> GetForSubmission(int id)
        {
            return _entities.UserVotes.Where(x => x.Submission.Id == id).ToList();
        }

        public int GetCountForSubmission(int id)
        {
            var submissions = GetForSubmission(id);
            return submissions.Count();
        }

        public void Add(UserVotes vote)
        {
            //var campaign 
            //var maxVotes = 

            vote.CreatedDate = DateTime.Now;
            vote.State = true;
            _entities.UserVotes.Add(vote);

            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var vote = _entities.UserVotes.FirstOrDefault(x => x.Id == id);

            if (vote == null)
            {
                throw new ApplicationException("You are bad!");
            }

            vote.State = false;

            _entities.SaveChanges();
        }

        public void Delete(UserVotes vote)
        {
            Delete(vote.Id);
        }

    }
}