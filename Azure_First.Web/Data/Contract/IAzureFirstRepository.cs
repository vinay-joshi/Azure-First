using Azure_First.Web.Entities;
using Azure_First.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_First.Web.Data.Contract
{
    public interface IAzureFirstRepository
    {
        Profile GetProfileByUserName(string username);
        List<RandomProfileViewModel> GetRandomProfiles(int numberToReturn);
        EditProfileViewModel GetUserProfileForEdit(string userName);
        Profile GetProfile(string memberName);
        string GetUserNameByMemberName(string memberName);
        bool SaveAll();
    }
}
