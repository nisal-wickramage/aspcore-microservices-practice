using System.Threading.Tasks;
using eVoting.Domain;
using MassTransit;
using System;

namespace eVoting.Worker
{
    public class VoteConsumer : IConsumer<Vote>
    {
        private readonly IVoteRepository _voteRepository;

        public Task Consume(ConsumeContext<Vote> context)
        {
            Console.WriteLine(context.Message.Option.ToString(), context.Message.VotedDateTime);
            return Task.CompletedTask;
        }
    }
}
