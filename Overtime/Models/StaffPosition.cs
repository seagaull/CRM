using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
 
    public class StaffPosition
    {
        public int StaffId { get; set; }
        public int PositionId { get; set; }

        public DateTime StartDate { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Position Position { get; set; }
    }

    public class StaffPositionMapping : EntityTypeConfiguration<StaffPosition>
    {
        public StaffPositionMapping()
        {
            this.ToTable("tbl_StaffPositions");
            this.HasKey(x => new
            {
                x.PositionId,
                x.StaffId
            });
            this.Property(x => x.PositionId);
            this.Property(x => x.StaffId);
            this.Property(x => x.StartDate);
            this.HasRequired(x => x.Staff).WithMany(x => x.Position);
            this.HasRequired(x => x.Position).WithMany(x => x.Staffs);

        }
    }
}