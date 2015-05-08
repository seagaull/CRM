using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class User : AbstractData
    {
        public User()
        {
            Roles = new List<Role>();
        }

        //private string _passwordhash;

        //public string Passwordhash
        //{
        //    get { return _passwordhash; }
        //    set { _passwordhash = SetPassword(value); }
        //}
        public string Passwordhash { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public virtual string SetPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Passwordhash);
        }
    }

    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("tbl_Users")
                .HasKey(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.CreatedBy).IsOptional();
            Property(x => x.CreatedTime).IsRequired();
            Property(x => x.ModifiedTime).IsOptional();
            Property(x => x.DeletedTime).IsOptional();
            Property(x => x.Passwordhash).IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            HasMany(x => x.Roles).WithMany(x => x.Users).Map
                (x =>
                {
                    x.ToTable("tbl_UsersRole");
                    x.MapLeftKey("UserId");
                    x.MapRightKey("RoleId");
                });
        }
    }
}