using DataAccess.Mapping;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NotebookContext : DbContext
    {
        public NotebookContext() : base("ENotebook")
        {

        }

        internal DbSet<User> User { get; set; }
        internal DbSet<Notebook> Notebook { get; set; }
        internal DbSet<Note> Note { get; set; }
        internal DbSet<Gender> Gender { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NotebookMap());
            modelBuilder.Configurations.Add(new NoteMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new GenderMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }
    }
}
