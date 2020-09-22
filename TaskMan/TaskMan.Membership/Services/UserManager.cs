using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TaskMan.Membership.Entities;

namespace TaskMan.Membership.Services
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, System.Collections.Generic.IEnumerable<IUserValidator<User>> userValidators, System.Collections.Generic.IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, Microsoft.Extensions.Logging.ILogger<UserManager<User>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
