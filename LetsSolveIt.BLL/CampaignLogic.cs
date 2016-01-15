using System;
using System.Collections.Generic;
using System.Linq;
using LetsSolveIt.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.BLL
{
    public class CampaignLogic
    {
        private readonly LetsSolveItContext _entities;

        public CampaignLogic(LetsSolveItContext entities)
        {
            _entities = entities;
        }

        public List<Campaigns> Get()
        {
            return _entities.Campaigns.ToList();
        }

        public Campaigns Get(int Id)
        {
            return _entities.Campaigns.FirstOrDefault(x => x.Id == Id);
        }

        public Campaigns Get(string name)
        {
            return _entities.Campaigns.FirstOrDefault(x => x.Name == name);
        }

        public List<Submissions> GetSubmissionsForCampaign(int id)
        {
            return _entities.Submissions.Where(x => x.Campaign.Id == id).ToList();
        }

        public List<int> GetSubmissionIdsForCampaign(int id)
        {
            return GetSubmissionsForCampaign(id).Select(x => x.Id).Distinct().ToList();
        }

        public void Save(Campaigns campaign)
        {
            var exists = _entities.Campaigns.FirstOrDefault(x => x.Id == campaign.Id);

            if (exists == null)
            {
                campaign.CreatedDate = DateTime.Now;
                campaign.LastModifiedDate = DateTime.Now;
                campaign.State = true;
                _entities.Campaigns.Add(campaign);
            }
            else
            {
                exists.Name = campaign.Name;
                exists.Category = campaign.Category;
                exists.Description = campaign.Description;
                exists.EndDate = campaign.EndDate;
                exists.InvitedUsers = campaign.InvitedUsers;
                exists.LastModifiedDate = DateTime.Now;
                exists.StartDate = campaign.StartDate;
                exists.State = campaign.State;
                exists.User = campaign.User;
            }
            _entities.SaveChanges();
        }

        public void Delete(int campaignId)
        {
            var campaign = _entities.Campaigns.FirstOrDefault(x => x.Id == campaignId);

            if (campaign == null)
            {
                throw new ApplicationException("You are bad!");
            }

            campaign.State = false;

            _entities.SaveChanges();
        }

        public void Delete(Campaigns campaign)
        {
            Delete(campaign.Id);
        }


    }
}
