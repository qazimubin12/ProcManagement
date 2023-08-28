using Microsoft.AspNet.Identity.EntityFramework;
using ProcManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcManagement.Database
{
    public class DSContext :IdentityDbContext<User>,IDisposable
    {
        public DSContext() : base("PCSConnectionStrings")
        {

        }

        public static DSContext Create()
        {
            return new DSContext();
        }



        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Entry> Entries { get; set; }

    }
}
