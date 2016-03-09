using Azure_First.Web.Data.Contract;
using System.Linq;
using Azure_First.Web.Entities;
using System;
using System.Collections.Generic;
using Azure_First.Web.Models;
using AutoMapper.QueryableExtensions;
namespace Azure_First.Web.Data
{
    public class AzureFirstRepository : IAzureFirstRepository
    {
        private AzureFirstContext _context;

        public AzureFirstRepository(AzureFirstContext context)
        {
            _context = context;
        }

        public Profile GetProfileByUserName(string userName)
        {
            var lowerUserName = userName.ToLowerInvariant();

             return _context.Profile
                           .Include("Demographics")
                           .Include("Interests.InterestType")
                           .Include("Photos")
                           .Include("Member")
                           .Where(m => m.Member.UserName.ToLower() == lowerUserName).FirstOrDefault();
        }

        public Profile GetProfile(string memberName)
        {
            var lowerMemberName = memberName.ToLowerInvariant();

            return _context.Profile
                           .Include("Demographics")
                           .Include("Interests.InterestType")
                           .Include("Photos")
                           .Include("Member")
                           .Where(m => m.Member.MemberName.ToLower() == lowerMemberName).FirstOrDefault();
        }

        public List<RandomProfileViewModel> GetRandomProfiles(int numberToReturn)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var profiles = _context.Profile.Include("Photos")
                                           .Include("Member")
                                           .OrderBy(p => Guid.NewGuid())
                                           .Take(numberToReturn)
                                           .ProjectTo<RandomProfileViewModel>()
#pragma warning restore CS0618 // Type or member is obsolete
                                           .ToList();
#pragma warning disable CS0618 // Type or member is obsolete
            //var randomProfiles = AutoMapper.Mapper.Map<List<Profile>, List<RandomProfileViewModel>>(profiles);
#pragma warning restore CS0618 // Type or member is obsolete
            return profiles;
        }

        public EditProfileViewModel GetUserProfileForEdit(string userName)
        {
            var query = _context.Profile
                          .Include("Demographics")
                          .Include("Member")
                        .Where(p => p.Member.UserName == userName)
                        .Select(p => new EditProfileViewModel()
                        {
                            Id = p.Id,
                            Pitch = p.Pitch,
                            LookingFor = p.LookingFor,
                            Introduction = p.Introduction,
                            Birthdate = p.Demographics.Birthdate,
                            Gender = p.Demographics.Gender,
                            Orientation = p.Demographics.Orientation,
                            MemberName = p.Member.MemberName
                        });
            return query.FirstOrDefault();
        }

        public bool SaveAll()
        {
            try
            {
                return _context.SaveChanges() > 0; // only return true if at least one row was changed
            }
            catch (Exception ex)
            {
                // TODO Add logging
                return false;
            }
        }

        public string GetUserNameByMemberName(string memberName)
        {
            return _context.Members.Where(m => m.MemberName == memberName).FirstOrDefault().UserName;
        }
    }
}