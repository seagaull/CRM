using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
    public class Position:AbstractData
    {
    
        public ICollection<StaffPosition> Staffs { get; set; }

    }

    public class PositionMapping : EntityTypeConfiguration<Position>
    {
        public PositionMapping()
        {
            this.ToTable("tbl_Positions")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();
           



            this.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(256);

          
        }
    }
}