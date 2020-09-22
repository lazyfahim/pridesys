using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMan.Membership.Services;

namespace TaskMan.API.DTOS.Register
{
    public class RegisterBaseDTO:IDisposable
    {
        protected UserManager userManager;
        public RegisterBaseDTO(UserManager manager)
        {
            userManager = manager;
        }
        public RegisterBaseDTO()
        {
            userManager = Startup.AutofacContainer.Resolve<UserManager>();
        }

        public void Dispose()
        {
            userManager?.Dispose();
        }
    }
}
