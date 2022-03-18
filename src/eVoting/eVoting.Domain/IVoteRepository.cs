using System;
namespace eVoting.Domain
{
    public interface IVoteRepository
    {
        void Save(Vote vote);
        void GetResult();
    }
}
