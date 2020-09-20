
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskMan.Membership.Entities;

namespace TaskMan.Membership.Contexts
{
    public class MemberShipContext : IdentityDbContext<User, Role, int, UserClaim,
        UserRole, UserLogin, RoleClaim, UserToken>
    {
        public MemberShipContext(DbContextOptions<MemberShipContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(p => p.ToTable("Users"));
            builder.Entity<Role>(p => p.ToTable("Roles"));
            builder.Entity<RoleClaim>(p => p.ToTable("RoleClaims"));
            builder.Entity<UserClaim>(p => p.ToTable("UserClaims"));
            builder.Entity<UserLogin>(p => p.ToTable("UserLogins"));
            builder.Entity<UserRole>(p => p.ToTable("UserRoles"));
            builder.Entity<UserToken>(p => p.ToTable("UserTokens"));
        }
    }
}