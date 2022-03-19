using System.Collections.Generic;

namespace eVoting.Domain
{
    public interface IVoteRepository
    {
        void Save(Vote vote);
        IList<KeyValuePair<VoteOptions, int>> GetResult();
    }
}
