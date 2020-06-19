using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WNS_DEMOPROJECT.Data;
using WNS_DEMOPROJECT.Models;

namespace WNS_DEMOPROJECT.Data
{
    public class WNS_DEMOPROJECTContext : DbContext
    {
        public WNS_DEMOPROJECTContext(DbContextOptions<WNS_DEMOPROJECTContext> options)
           : base(options)
        {
        }

        public DbSet<PatientData> PatientDatas { get; set; }
    }

}
