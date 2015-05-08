using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class SubPosition : AbstractData
    {
        public SubPosition()
        {
            Staff = new List<StaffPosition>();
        }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<StaffPosition> Staff { get; set; }
    }

    public class SubPositionMapping : EntityTypeConfiguration<SubPosition>
    {
        public SubPositionMapping()
        {
            ToTable("tbl_SubPositions")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CreatedBy).IsRequired();
            Property(x => x.CreatedTime).IsRequired();
            Property(x => x.ModifiedTime).IsOptional();
            Property(x => x.DeletedTime).IsOptional();
        }
    }
}