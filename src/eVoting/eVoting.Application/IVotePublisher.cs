using System.Threading.Tasks;
using eVoting.Domain;

namespace eVoting.Application
{
    public interface IVotePublisher
    {
        Task Publish(Vote vote);
    }
}
