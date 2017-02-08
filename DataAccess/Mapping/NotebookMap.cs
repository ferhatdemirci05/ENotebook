using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class NotebookMap : EntityTypeConfiguration<Notebook>
    {
        public NotebookMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.DateOfCration).HasColumnType("Date");
            HasRequired(x => x.User).WithMany(x => x.Notebooks).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
