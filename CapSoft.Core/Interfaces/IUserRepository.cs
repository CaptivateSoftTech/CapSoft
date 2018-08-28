using CapSoft.Core.Infrastructure;
using CapSoft.Core.Models;
using CapSoft.Core.ViewModels;
using System.Collections.Generic;


namespace CapSoft.Core.Interfaces
{

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<UserViewModel> SearchUsers(SearchUserViewModel SearchUser);
        IEnumerable<UserViewModel> GetUsers(string UserTypeCode);

        User GetUserForRestPassword(int userId);

        void UpdateUsers(User _User);
        void ResetPassword(User _User);

        string GetRoleName(int RoleId);
        void RemoveRole(int UserId);


    }
}
