using System;
using System.Collections.Generic;
using System.Linq;
using CapSoft.Core.Infrastructure;
using CapSoft.Core.Models;
using CapSoft.Core.ViewModels;
using AutoMapper;
using System.Data.Entity;
using CapSoft.Core.Interfaces;

namespace CapSoft.Core.Repositories
{
   public class UsersRepository : RepositoryBase<User>, IUserRepository
    {
        public UsersRepository(IDbFactory DbFactory) : base(DbFactory) { }

        public IEnumerable<UserViewModel> SearchUsers(SearchUserViewModel SearchUser)
        {
            List<User> Users = DbContext.Users.Where(e => e.Email == SearchUser.Email).ToList();
            
            IEnumerable<UserViewModel> _users = Mapper.Map<IEnumerable<UserViewModel>>(Users);

            return _users;

        }

        public void ResetPassword(User _User)
        {
            base.Update(_User);
        }
        public void UpdateUsers(User _User)
        {
            Update(_User);
        }

        public override void Update(User _User)
        {

            DbContext.Users.Attach(_User);
            DbContext.Entry(_User).State = EntityState.Modified;
            DbContext.Entry(_User).Property(x => x.PasswordHash).IsModified = false;
            DbContext.Entry(_User).Property(x => x.SecurityStamp).IsModified = false;
            DbContext.SaveChanges();



        }

        public IEnumerable<UserViewModel> GetUsers(string UserTypeCode)
        {
            
            var Users = DbContext.Users.Include("UserRoles").Where(e => e.UserTypeCode == UserTypeCode && e.UserRoles.Any(c => c.RoleId != 1)).OrderByDescending(e => e.ModifiedDate).ToList();
            IEnumerable<UserViewModel> _users = Mapper.Map<IEnumerable<UserViewModel>>(Users);

            return _users;
            

        }
        public User GetUserForRestPassword(int userid)
        {
            User _User = DbContext.Users.Where(x => x.Id == userid).FirstOrDefault();
            return _User;
        }
      

        public string GetRoleName(int RoleId)
        {
            Roles RoleName = DbContext.Roles.Where(x => x.Id == RoleId).FirstOrDefault();
            return RoleName.Name.ToString();
        }
        public void RemoveRole(int UserId)
        {
            UserRole role = DbContext.UserRole.Where(X => X.UserId == UserId).FirstOrDefault();
            DbContext.UserRole.Remove(role);
            DbContext.SaveChanges();
        }



    }

}
