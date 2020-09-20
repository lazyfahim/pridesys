using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Repos;
using TaskMan.Framework.Services;
using TaskMan.Framework.UOW;

namespace TaskMan.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            // Bind Implementation with the interfaces here
            builder.RegisterType<PostUnitOfWork>().As<IPostUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PostService>().As<IPostService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FrameworkDataSeeder>(); // For Running Migration of Framework & Seeding Data if required

            base.Load(builder);
        }
    }

}
