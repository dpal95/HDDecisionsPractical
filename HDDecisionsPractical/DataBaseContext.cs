using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HDDecisionsPractical.Models;
using System.Data.Entity;
namespace HDDecisionsPractical
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DataBaseContext")
        {
            
        }
        public DbSet<ApplicantModel> Applicants { get; set; }
    }
}