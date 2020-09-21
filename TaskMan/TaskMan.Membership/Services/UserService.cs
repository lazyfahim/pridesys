
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Common.Exceptions;
using TaskMan.Membership.Entities;
using TaskMan.Membership.Exceptions;
using TaskMan.Membership.UnitOfWorks;

namespace TaskMan.Membership.Services
{
    public class UserService : IUserService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly UserManager _userManager;
        private readonly SigninManager _signInManager;
        public UserService(IUserUnitOfWork userUnitOfWork, UserManager userManager, SigninManager signInManager)
        {
            _userUnitOfWork = userUnitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void Dispose()
        {
            _userUnitOfWork?.Dispose();
        }

        public User GetUserDetails(int userId)
        {
            if (userId == 0 || userId < 0)
            {
                throw new Exception("User not found");
            }

            return _userUnitOfWork.UserRepository.GetById(userId);
        }

        public void EditUser(User user)
        {
            if (user == null)
            {
                throw new EntityNullException<User>();
            }

            var existingUser = _userUnitOfWork.UserRepository.GetById(user.Id);

            if (existingUser == null)
            {
                throw new DbEntityNotFound("Error. User not found", nameof(User));
            }

            existingUser.Company = user.Company;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Website = user.Website;

            _userUnitOfWork.UserRepository.Edit(existingUser);
            _userUnitOfWork.Save();
        }

        public void EditProfilePicture(User user)
        {
            if (user == null)
            {
                throw new EntityNullException<User>();
            }

            var existingUser = _userUnitOfWork.UserRepository.GetById(user.Id);

            if (existingUser == null)
            {
                throw new DbEntityNotFound("Error. User not found", nameof(User));
            }

            existingUser.ProfilePicture = user.ProfilePicture;

            _userUnitOfWork.UserRepository.Edit(existingUser);
            _userUnitOfWork.Save();
        }

        public async Task<string> GetToken(string username, string password,byte[] key)
        {
            if (username != null && password != null)
            {
                var user = await _userManager.FindByEmailAsync(username);
                if(user == null)
                    user = await _userManager.FindByNameAsync(username);
                if (user == null)
                    throw new Exception("username or email not found!!!");
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

                if (result != null && result.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserId", user.Id.ToString()),
                            new Claim(ClaimTypes.Name,user.UserName.ToString()),
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return tokenHandler.WriteToken(token);
                }
                else
                {
                    throw new Exception("Username or password is incorrect");
                }
            }
            else
                throw new Exception("error has happend in server");
        }
    }
}
