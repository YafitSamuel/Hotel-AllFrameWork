using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Hotel_AllFrameWork.Models
{
    public partial class HotelDataContext : DbContext
    {
        public HotelDataContext()
            : base("name=HotelDataContext")
        {

        }
          public virtual  DbSet<Claient> Claients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
