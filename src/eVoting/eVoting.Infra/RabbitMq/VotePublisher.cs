using System.Threading.Tasks;
using eVoting.Application;
using eVoting.Domain;
using MassTransit;

namespace eVoting.Infra.RabbitMq
{
    public class VotePublisher : IVotePublisher
    {
        private readonly IBus _bus;

        public VotePublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task Publish(Vote vote)
        {
            await _bus.Publish(vote);
        }
    }
}
