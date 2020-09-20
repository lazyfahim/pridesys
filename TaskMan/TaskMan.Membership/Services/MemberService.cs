
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMan.Common.Exceptions;
using TaskMan.Membership.Entities;
using TaskMan.Membership.UnitOfWorks;

namespace TaskMan.Membership.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly ILogger<MemberService> _logger;

        public MemberService(IUserUnitOfWork userUnitOfWork, ILogger<MemberService> logger)
        {
            _userUnitOfWork = userUnitOfWork;
            _logger = logger;
        }

        public (IList<User> records, int total, int totalDisplay) GetUserList(int pageIndex, int pageSize, string searchText, string sortText)
        {
            _logger.LogInformation("Getting user id's from database for role MEMBER");
            
            var userIds = _userUnitOfWork.UserRepository.GetUserIdListOfProvidedRole("MEMBER");
            
            _logger.LogInformation($"User id's received. Found {userIds.Count} users for role members");

            _logger.LogInformation($"Getting information about users from database");

            var (data, total, totalDisplay) = _userUnitOfWork.UserRepository.GetDynamic(
                        x => userIds.Any(c => c == x.Id) && 
                        (x.UserName.Contains(searchText) || x.Email.Contains(searchText)),
                        sortText, null, pageIndex, pageSize, true);

            _logger.LogInformation("Returing the data received from database");

            return (data, total, totalDisplay);

        }

        public User GetUser(int id)
        {
            if (id == 0 || id < 0)
            {
                _logger.LogInformation($"Received id {id}");
                throw new IdCannotBeZeroOrNegativeException($"User Id cannot be {id}", nameof(User));
            }

            var user = _userUnitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                _logger.LogInformation($"No user was found with id {id}");
                throw new DbEntityNotFound($"User with id {id} does not exist", nameof(User));
            }

            _logger.LogInformation($"Returing user data retrieved from database");
            return user;
        }

        public void UpdateUserInformation(User user)
        {
            if (user is null)
            {
                _logger.LogInformation($"Null entity found of type {nameof(User)}");
                throw new ArgumentNullException("Null reference entity");
            }

            _logger.LogInformation($"Initiating update command for user {user.Id} with username {user.UserName}");
            var dbUser = _userUnitOfWork.UserRepository.GetById(user.Id);

            if (dbUser == null)
            {
                _logger.LogInformation($"Failed to retrive data from db for update of user with id {user.Id}");
                throw new DbEntityNotFound($"Failed to update information", nameof(User));
            }

            dbUser.IsBlocked = user.IsBlocked;
            dbUser.PhoneNumber = user.PhoneNumber;

            _userUnitOfWork.Save();
        }

        public void Dispose()
        {
            _userUnitOfWork?.Dispose();
        }
    }
}
