using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
    public class SubPosition:AbstractData
    {
        public int PositionId { get; set; } 
        public virtual Position Position { get; set; }
        public virtual ICollection<StaffPosition> Staff { get; set; }

    }

    public class SubPositionMapping : EntityTypeConfiguration<SubPosition>
    {
        public SubPositionMapping()
        {
            this.ToTable("tbl_SubPositions")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();


          

        }


    }
}