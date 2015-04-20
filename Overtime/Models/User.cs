using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
    public class User:AbstractData
    {


        public User()
        {
            Roles= new List<Role>();
        }


        //private string _passwordhash;

        //public string Passwordhash
        //{
        //    get { return _passwordhash; }
        //    set { _passwordhash = SetPassword(value); }
        //}
        public string Passwordhash { get; set; }
        public virtual string SetPassword(string password)
        {
            return  BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Passwordhash);
        }

        public virtual ICollection<Role> Roles { get; set; }
     

    }

    public class UserMapping:EntityTypeConfiguration<User>
    {

        public UserMapping()
        {
            this.ToTable("tbl_Users")
                .HasKey(x => x.Id)
                .Property(x=>x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                
           
            this.Property(x => x.CreatedBy).IsOptional();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();
            this.Property(x => x.Passwordhash).IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            this.HasMany(x => x.Roles).WithMany(x => x.Users).Map
            (x =>
            {
                x.ToTable("tbl_UsersRole");
                x.MapLeftKey("UserId");
                x.MapRightKey("RoleId");
                
            });
            

        }
    }


}