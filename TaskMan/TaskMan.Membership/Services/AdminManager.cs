
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMan.Membership.Entities;
using TaskMan.Membership.UnitOfWorks;

namespace TaskMan.Membership.Services
{
    public class AdminManager : IAdminManager
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly ILogger<AdminManager> _logger;

        public AdminManager(IUserUnitOfWork userUnitOfWork, ILogger<AdminManager> logger)
        {
            _userUnitOfWork = userUnitOfWork;
            _logger = logger;
        }

        public (IList<User> records, int total, int totalDisplay) GetAdminList(int pageIndex, int pageSize, string searchText, string sortText)
        {
            _logger.LogInformation("Getting user id's from database for role ADMIN");

            var userIds = _userUnitOfWork.UserRepository.GetUserIdListOfProvidedRole("ADMIN");

            _logger.LogInformation($"User id's received. Found {userIds.Count} users for role Admin");

            _logger.LogInformation($"Getting information about users from database");

            var (data, total, totalDisplay) = _userUnitOfWork.UserRepository.GetDynamic(
                        x => userIds.Any(c => c == x.Id) &&
                        (x.UserName.Contains(searchText) || x.Email.Contains(searchText)),
                        sortText, null, pageIndex, pageSize, true);

            _logger.LogInformation("Returing the data received from database");

            return (data, total, totalDisplay);

        }
    }
}
