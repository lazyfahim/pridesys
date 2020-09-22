using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Membership.DataSeed;
using TaskMan.Membership.Repositories;
using TaskMan.Membership.Services;
using TaskMan.Membership.UnitOfWorks;

namespace TaskMan.Membership
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Bind Implementation with the interfaces here

            builder.RegisterType<UserRepository>().As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserUnitOfWork>().As<IUserUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MemberService>().As<IMemberService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AdminManager>().As<IAdminManager>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<UserService>().As<IUserService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<UserDataSeeder>();

            base.Load(builder);
        }
    }
}
