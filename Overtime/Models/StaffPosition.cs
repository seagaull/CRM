using System;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class StaffPosition
    {
        public int StaffId { get; set; }
        public int PositionId { get; set; }
        public DateTime? StartDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SubPosition SubPosition { get; set; }
    }

    public class StaffPositionMapping : EntityTypeConfiguration<StaffPosition>
    {
        public StaffPositionMapping()
        {
            ToTable("tbl_StaffPositions");
            HasKey(x => new
            {
                x.PositionId,
                x.StaffId
            });
            Property(x => x.PositionId);
            Property(x => x.StaffId);
            Property(x => x.StartDate);

            HasRequired(x => x.Employee)
                .WithMany(x => x.SubPositions)
                .HasForeignKey(x => x.StaffId);


            HasRequired(x => x.SubPosition)
                .WithMany(x => x.Staff)
                .HasForeignKey(x => x.PositionId);
        }
    }
}