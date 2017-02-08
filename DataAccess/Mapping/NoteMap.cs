using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class NoteMap : EntityTypeConfiguration<Note>
    {
        public NoteMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.Description).IsOptional().HasColumnType("varchar").HasMaxLength(5000);
            Property(x => x.Hit).HasColumnType("int");
            Property(x => x.Flag).HasColumnType("bit");
            Property(x => x.Share).HasColumnType("bit");
            HasRequired(x => x.Notebook).WithMany(x => x.Notes).HasForeignKey(x => x.NotebookID).WillCascadeOnDelete(true);
        }
    }
}
