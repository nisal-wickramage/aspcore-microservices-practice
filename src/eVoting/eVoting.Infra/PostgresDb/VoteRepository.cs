using System.Linq;
using System.Collections.Generic;
using eVoting.Domain;

namespace eVoting.Infra.PostgresDb
{
    public class VoteRepository: IVoteRepository
    {
        private readonly EVotingDbContext _dbContext;
        public VoteRepository(EVotingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<KeyValuePair<VoteOptions, int>> GetResult()
        {
            var result = _dbContext.Votes
                .GroupBy(v => v.Option)
                .Select(group => new KeyValuePair<VoteOptions, int>((VoteOptions)group.Key, group.Count()))
                .ToList();

            return result;
        }

        public void Save(Vote vote)
        {
            _dbContext.Database.EnsureCreated();
            _dbContext.Votes.Add(new VoteDbModel { Option = (int)vote.Option, VotedDateTime = vote.VotedDateTime });
            _dbContext.SaveChanges();
        }
    }
}
