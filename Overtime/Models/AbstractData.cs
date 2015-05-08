using System;

namespace Overtime.Models
{
    public abstract class AbstractData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? DeletedTime { get; set; }

        public bool IsDeleted
        {
            get { return DeletedTime != null; }
        }
    }
}