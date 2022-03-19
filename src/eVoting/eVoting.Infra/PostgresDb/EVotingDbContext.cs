using System;
using Microsoft.EntityFrameworkCore;

namespace eVoting.Infra.PostgresDb
{
    public class EVotingDbContext: DbContext
    {
        public EVotingDbContext(DbContextOptions<EVotingDbContext> options) : base(options)
        {

        }
        public DbSet<VoteDbModel> Votes { get; set; }
    }
}
