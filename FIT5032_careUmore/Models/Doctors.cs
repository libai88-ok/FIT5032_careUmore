using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FIT5032_careUmore.Models
{
    public partial class Doctors : DbContext
    {
        public Doctors()
            : base("name=Doctors")
        {
        }

        public virtual DbSet<Dotor> Dotors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
