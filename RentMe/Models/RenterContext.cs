using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentMe.Models
{
    public class RenterContext : DbContext
    {
      public  DbSet<Renter> rentalproperties { get; set; }

    }

}