
using System.Threading.Tasks;
using eVoting.Domain;

namespace eVoting.Application
{
    public interface IVoteConsumer
    {
        Task Consume(Vote vote);
    }
}
