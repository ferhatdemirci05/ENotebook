using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.ID);
            Property(x => x.FirstName).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            Property(x => x.EMail).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Password).IsRequired().HasColumnType("varchar").HasMaxLength(32);
            HasRequired(x => x.Gender).WithMany().HasForeignKey(x => x.GenderID).WillCascadeOnDelete(false);
        }
    }
}
