using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class GenderMap : EntityTypeConfiguration<Gender>
    {
        public GenderMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Name).HasColumnType("varchar").HasMaxLength(10).IsRequired();
        }
    }
}
