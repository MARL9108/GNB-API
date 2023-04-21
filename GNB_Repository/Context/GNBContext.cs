using GNB_Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Repository.Context
{
    public class GNBContext: DbContext
    {
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public GNBContext(DbContextOptions<GNBContext> options): base(options) {}
    }
}
