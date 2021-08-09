using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace ERP.Models
{
    public class Signupbussinesslayer : DbContext
    {
        public Signupbussinesslayer() : base("DBCS") { }
        public DbSet<SignUpDetails> SignUpDetailsTable { get; set; }
    }
}