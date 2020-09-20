using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskMan.Membership.Entities;
using TaskMan.Membership.Services;

namespace TaskMan.API.DTOS.Register
{
    public class RegisterDTO:RegisterBaseDTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "PassWord is Required")]
        [StringLength(100, ErrorMessage = "Must be between 5 and 100 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public RegisterDTO(UserManager userManager):base(userManager)
        {

        }
        public RegisterDTO():base()
        {
        }
        public async Task<bool> IsExistEmailorUser(string usernameoremail, bool isemail)
        {
            if (isemail)
            {
                var user = await userManager.FindByEmailAsync(usernameoremail);
                if (user != null)
                    return true;
            }
            else
            {
                var user = await userManager.FindByNameAsync(usernameoremail);
                if (user != null)
                    return true;
            }
            return false;
        }
        public async Task<(bool, IList<string>)> Create()
        {
            var user = new User()
            {
                UserName = this.UserName,
                Email = this.Email,
            };
            var result = await userManager.CreateAsync(user, this.PassWord);
            if (result.Succeeded)
            {
                return (true, null);
            }
            else
                return (false, result.Errors.Select(x => x.Description).ToList());

        }
    }
}
