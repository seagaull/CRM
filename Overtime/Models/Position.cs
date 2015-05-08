using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class Position : AbstractData
    {
        public Position()
        {
            SubPositions = new List<SubPosition>();
        }

        public virtual ICollection<SubPosition> SubPositions { get; set; }
    }

    public class PositionMapping : EntityTypeConfiguration<Position>
    {
        public PositionMapping()
        {
            ToTable("tbl_Positions")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CreatedBy).IsRequired();
            Property(x => x.CreatedTime).IsRequired();
            Property(x => x.ModifiedTime).IsOptional();
            Property(x => x.DeletedTime).IsOptional();


            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(256);
        }
    }
}